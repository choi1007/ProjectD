using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Data;

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
        public abstract void Hit(Damage _damage);
    }
}