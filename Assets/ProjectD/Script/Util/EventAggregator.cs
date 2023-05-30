using System;
using System.Collections.Generic;

public class EventAggregator : LazySingleton<EventAggregator>
{
    private Dictionary<Type, Delegate> _delegates { get; set; } = new Dictionary<Type, Delegate>();

    public void Subscribe<T>(Action<T> callback) where T : struct
    {
        //lock (_actions)
        {
            // performance http://www.thejoyofcode.com/Performance_of_Method.Invoke_vs_a_Delegate.aspx
            //System.Delegate.CreateDelegate(typeof(Action<T>), obj, type.Name);

            var type = typeof(T);
            if (_delegates.ContainsKey(type) == false)
            {
                _delegates.Add(type, callback);
                return;
            }

            var action = _delegates[type] as Action<T>;
            action -= callback;
            action += callback;
            _delegates[type] = action;
        }
    }

    public void Unsubscribe<T>(Action<T> callback) where T : struct
    {
        //lock (_actions)
        {
            var type = typeof(T);
            if (_delegates.ContainsKey(type) == false) return;

            var action = _delegates[type] as Action<T>;
            _delegates[type] = action -= callback;

            if (action == null) _delegates.Remove(type);
        }
    }

    public void Publish<T>(T eventData) where T : struct
    {
        //lock (_actions)
        {
            var type = typeof(T);
            if (_delegates.ContainsKey(type) == false) return;

            var actions = _delegates[type] as Action<T>;
            actions(eventData);
        }
    }
}