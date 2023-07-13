using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;
using GameData;
using Pathfinding;

public class Player : Actor
{
<<<<<<< HEAD
    [SerializeField] private LayerMask ClickLayer;
    [SerializeField] private Transform TouchObject;
    
    [SerializeField] private Transform RifleWeaponPos;
    [SerializeField] private Transform SniperWeaponPos;

    [SerializeField] private float EndPosNearDistance;

    private Camera MainCamera;
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
=======
    [SerializeField] private AISensor Scan;
    
    public void InitPlayerData()
    {
        Fsm.ChangeState(ActorState.Idle);
    }

    private void Update()
    {
        Scan.Scan();
    }

    public override void Attack()
>>>>>>> 030fbaec27f824ece65b8191e92109d0401970fc
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
                TouchObject.transform.position = hit.point;
                Astar.destination = hit.point;
                MainWeapon.WeaponMotionChange(WeaponPos.Type.Move);
            }
        }

        if (Vector3.Distance(transform.position, Astar.destination) < EndPosNearDistance && ActorMove)
        {
            ActorMove = false;
            MainWeapon.WeaponMotionChange(WeaponPos.Type.Stop);
        }

        if (Astar.hasPath) Fsm.PlayAnimation("Walk", Astar.remainingDistance);
    }

    public override void Hit(Damage _damage)
    {

    }
}
