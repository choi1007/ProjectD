using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Weapon;
using DataEnum;
using System.Linq;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]
    private Transform _weaponBulletEffect = null;

    [SerializeField]
    private GameObject _effectObject = null;

    [SerializeField]
    private List<WeaponPos> _weaponPosType = new List<WeaponPos>();

    private WeaponDataBase _weaponDataBase = new WeaponDataBase();
    private int _bullet = 0;

    protected float AttackRateTime = 0;
    protected Player Player = null;

    protected Transform WeaponBulletEffect
    {
        get => _weaponBulletEffect;
    }

    protected GameObject EffectObject
    {
        get => _effectObject;
    }

    protected List<WeaponPos> WeaponPosType
    {
        get => _weaponPosType;
    }

    public WeaponDataBase WeaponDataBase
    {
        get => _weaponDataBase;
        protected set => _weaponDataBase = value;
    }

    public int Bullet
    {
        get => _bullet;
        protected set => _bullet = value;
    }

    public abstract void InitWeapon(uint _weaponId, Player _player);
    public abstract bool Fire();
    public abstract void Realod();

    public void WeaponMotionChange(eWeaponPosType _type)
    {
        var _wpos = _weaponPosType.Where(x => x.AnimType == _type).FirstOrDefault();
        var _parent = transform.parent;

        switch (_type)
        {
            case eWeaponPosType.Stop:
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
