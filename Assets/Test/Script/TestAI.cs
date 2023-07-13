using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TestAI : MonoBehaviour
{
    public Transform Target;

    IAstarAI ai;

    public bool clickTest = false;
    public Camera main;

    private void Awake()
    {
        ai = GetComponent<IAstarAI>();
    }

    private void OnEnable()
    {
        ai.onSearchPath += Update;
    }

    private void OnDisable()
    {
        ai.onSearchPath -= Update;
    }


    // Update is called once per frame
    void Update()
    {
        if (clickTest)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                var ray = main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    ai.destination = hit.point;
                }
            }
            return;
        }

        if (Target != null && ai != null) ai.destination = Target.position;
    }
}
