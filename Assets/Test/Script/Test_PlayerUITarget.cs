using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class Test_PlayerUITarget : MonoBehaviour
    {
        [SerializeField] private Camera Camera;
        [SerializeField] private Collider Collider;

        Plane[] cameraFrustume;

        private MeshRenderer render;

        private void Start()
        {
            render = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            var bounds = Collider.bounds;
            cameraFrustume = GeometryUtility.CalculateFrustumPlanes(Camera);
            if (GeometryUtility.TestPlanesAABB(cameraFrustume, bounds))
            {
                render.sharedMaterial.color = Color.green;
                Debug.Log("in");
            }
            else
            {
                render.sharedMaterial.color = Color.red;
                Debug.Log("out");
            }
        }
    }
}