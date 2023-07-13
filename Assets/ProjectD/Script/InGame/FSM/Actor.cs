using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using GameData;

namespace InGame
{
    public abstract class Actor : MonoBehaviour
    {
        [HideInInspector]
        public IAstarAI Astar;

        [HideInInspector]
        public Vector3 OriginPos;
        
        public float AttackDistance;

        public FSM Fsm;

        public CharData CharData;

<<<<<<< HEAD
        public abstract void Hit(Damage _damage);
=======
        public float AttackDist = 1f;

        public bool IsRange = false;

        public abstract void Attack();
        public abstract void Hit(int _damage);
        public bool BulletReady() { return (BulletWaitTime < Time.time); }
>>>>>>> 030fbaec27f824ece65b8191e92109d0401970fc
    }
}