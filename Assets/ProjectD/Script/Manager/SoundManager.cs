using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public class SoundData
    {
        public string SoundKey;
        public string SoundPath;
        public float Volume;
        public float StartTime;
    }

    private Dictionary<string, SoundData> m_soundDic = new Dictionary<string, SoundData>();
    
    public void OnWake() { }

    public void OnSoundInitialized()
    {
        //var _soundList = TableManager.Instance.SoundExcel.SoundSheet;
        //var _soundData = new SoundData();

        //m_soundDic.Clear();
        //for (int i = 0; i < _soundList.Count; i++)
        //{
        //    var _soundTableData = _soundList[i];
        //    _soundData.SoundKey = _soundTableData.StringKey;
        //    _soundData.Volume = _soundTableData.Volume;
        //    _soundData.StartTime = _soundTableData.StartTime;
        //    _soundData.SoundPath = $"Sounds/{_soundTableData.Path}";
        //    m_soundDic.Add(_soundData.SoundKey, _soundData);
        //}
    }

    public string FindSoundPath(string _key) => m_soundDic.ContainsKey(_key) == true ? m_soundDic[_key].SoundPath : string.Empty;
}
