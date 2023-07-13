using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

[Serializable]
public class WeaponPos
{
    public enum Type
    {
        Stop,
        Move,
    }

    public Type AnimType;
    public Quaternion Rot;
    public Vector3 Pos;
}

public abstract class WeaponBase : MonoBehaviour
{
    public Transform WeaponBulletEffect;
    public GameObject EffectObject;
    public List<WeaponPos> WeaponPosType;

    public WeaponData WeaponData { get; protected set; }
    public int Bullet { get; protected set; }

    protected float AttackRateTime;

    protected Player Player;

    private void Awake()
    {
        WeaponData = new WeaponData();
    }

    public abstract void InitWeapon(uint _weaponId, Player _player);
    public abstract bool Fire();
    public abstract void Realod();

    public void WeaponMotionChange(WeaponPos.Type _type)
    {
        var _wpos = WeaponPosType.Find(x => x.AnimType == _type);
        var _parent = transform.parent;

        switch (_type)
        {
            case WeaponPos.Type.Stop:
                {
                    StopAllCoroutines();
                    StartCoroutine(WeaponMotionChange(_parent, _wpos));
                }
                break;
            default:
                _parent.localPosition = _wpos.Pos;
                _parent.localRotation = _wpos.Rot;
                break;
        }
    }

    protected IEnumerator WeaponMotionChange(Transform _parent, WeaponPos _wpos)
    {
        float _time = 0;
        var parpos = _parent.localPosition;
        var parrot = _parent.localRotation;
        while (1f > _time)
        {
            _time += 0.1f;
            _parent.localPosition = Vector3.Lerp(parpos, _wpos.Pos, _time);
            _parent.localRotation = Quaternion.Lerp(parrot, _wpos.Rot, _time);
            yield return WaitSecondPool.Get(0.01f);
        }
        _parent.localPosition = _wpos.Pos;
        _parent.localRotation = _wpos.Rot;
    }
}
