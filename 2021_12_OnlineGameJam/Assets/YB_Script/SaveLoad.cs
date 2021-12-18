using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameObject Flag;

    private void Start()
    {
        Flag.SetActive(false);
    }

    void Update()
    {
        Save();
    }

    void Save()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (true) //if(IsGround)
            {
                Flag.SetActive(true);
                Flag.transform.position = transform.position - new Vector3(0,0.5f,0f);
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (true) //if(IsGround)
            {
                transform.position = Flag.transform.position + new Vector3(0,0.5f,0f);;
            }
        }
    }
    
}
