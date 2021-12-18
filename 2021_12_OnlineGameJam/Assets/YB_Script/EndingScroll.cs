using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScroll : MonoBehaviour
{
    public float ScrollSpeed = 20; // ��ũ�� �ö󰡴� �ӵ�

    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);

        pos += localVectorUp * ScrollSpeed * Time.deltaTime;
        
        transform.position = pos;
        
    }
}
