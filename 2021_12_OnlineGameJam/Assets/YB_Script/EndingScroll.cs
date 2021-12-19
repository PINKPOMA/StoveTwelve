using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScroll : MonoBehaviour
{
    public float ScrollSpeed = 20; // 스크롤 올라가는 속도

    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);
        if (Input.GetKey(KeyCode.Space))
        {
            pos += localVectorUp * (ScrollSpeed * 3)*Time.deltaTime;
        }
        else
        {
            pos += localVectorUp * ScrollSpeed * Time.deltaTime;
        }
        
        
        transform.position = pos;
        
    }
}
