using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCamera : MonoBehaviour
{
    public Vector3 Offset = new Vector3(0f, 7.5f, 0f);
    private Vector3 CameraPos = new Vector3();

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W)) Move(true, 1);
        if (Input.GetKey(KeyCode.S)) Move(true, -1);
        if (Input.GetKey(KeyCode.A)) Move(false, -1);
        if (Input.GetKey(KeyCode.D)) Move(false, 1);
    }

    private void Move(bool _updown, float _movePos)
    {
        _movePos *= 0.5f;

        if (_updown) CameraPos.z += _movePos;
        else CameraPos.x += _movePos;
        transform.position = CameraPos + Offset;
    }
}
