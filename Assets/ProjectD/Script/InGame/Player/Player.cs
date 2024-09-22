using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;
using Data;
using DataEnum;
using Pathfinding;

public class Player : Actor
{
    [SerializeField] private LayerMask ClickLayer;
    
    [SerializeField] private Transform RifleWeaponPos;
    [SerializeField] private Transform SniperWeaponPos;

    [SerializeField] private float EndPosNearDistance;

    private Camera MainCamera;
    private Transform TouchEffect;

    private PlayerData PlayerData;

    private WeaponBase MainWeapon;

    private bool ActorMove;

    private void Awake()
    {
        Astar = GetComponent<IAstarAI>();
    }

    private void OnEnable()
    {
        Astar.onSearchPath += Update;
    }

    private void OnDisable()
    {
        Astar.onSearchPath -= Update;
    }


    private void Start()
    {
        InitPlayer();
    }

    public void InitPlayer()
    {
        //player Init
        ActorMove = false;
        MainCamera = InGameManager.Instance.PlayerCamera;

        //weapon Init
        MainWeapon = Util.GetPrefab<WeaponBase>("Prefabs/InGame/Weapon/Rifle01");
        MainWeapon.InitWeapon(0, this);
        MainWeapon.transform.SetParent(RifleWeaponPos, false);

        //TouchEffect
        TouchEffect = Util.GetPrefab<Transform>("Prefabs/InGame/Effect/TouchEffect");

        //fsm init
        FSM.FSMState.Regist(new PlayerIdleState(), Fsm);
        FSM.FSMState.Regist(new PlayerAttackState(MainWeapon), Fsm);
        FSM.FSMState.Regist(new PlayerGetItemState(), Fsm);
        Fsm.ChangeState(ActorState.Idle);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, ClickLayer))
            {
                ActorMove = true;
                TouchEffect.transform.position = hit.point;
                Astar.destination = hit.point;
                MainWeapon.WeaponMotionChange(eWeaponPosType.Move);
            }
        }

        if (Vector3.Distance(transform.position, Astar.destination) < EndPosNearDistance && ActorMove)
        {
            ActorMove = false;
            MainWeapon.WeaponMotionChange(eWeaponPosType.Stop);
        }

        if (Astar.hasPath) Fsm.PlayAnimation("Walk", Astar.remainingDistance);
    }

    public override void Hit(Damage _damage)
    {

    }
}
