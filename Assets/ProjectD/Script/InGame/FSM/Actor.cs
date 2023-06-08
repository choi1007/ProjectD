using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;
//using Elendow.SpritedowAnimator;

namespace InGame
{
    public abstract class Actor : MonoBehaviour
    {
        public FSM Fsm;

        //[BoxGroup("Stat/Range"), ShowIf(nameof(isRange)), ReadOnly]
        public float BulletWaitTime;

        public float AttackDist = 1f;

        public bool IsRange = false;

        public abstract void Attack();
        public abstract void Hit(int _damage);
        public bool BulletReady() { return (BulletWaitTime < Time.time); }
    }
}