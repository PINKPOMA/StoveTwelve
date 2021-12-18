using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{

    public void JumpEventEnd()
    {
        gameObject.SetActive(false);
    }
}
