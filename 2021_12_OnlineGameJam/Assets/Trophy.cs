using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Trophy : MonoBehaviour
{
    public float speed;
    void Start()
    {
        transform.DOMoveY(0.5f,speed).SetRelative().SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame
}
