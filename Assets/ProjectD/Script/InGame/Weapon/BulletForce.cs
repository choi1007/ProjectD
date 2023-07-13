using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class BulletForce : MonoBehaviour
{
    private float m_returnTime;

    private void OnEnable()
    {
        m_returnTime = 0;
    }

    void Update()
    {
        m_returnTime += Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * 100f);
        if (m_returnTime > 1)
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
    }

}
