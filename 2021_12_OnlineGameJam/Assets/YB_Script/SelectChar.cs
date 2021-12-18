using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Charactor charactor;
    private Animator anim;
    private SpriteRenderer sr;
    public SelectChar[] chars;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        if(dataManager.instance.CurrentCharactor == charactor)
            OnSelect();
        else
            OnDeSelect();
    }

    private void OnMouseUpAsButton()
    {
        dataManager.instance.CurrentCharactor = charactor;
        OnSelect();
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != this)
                chars[i].OnDeSelect();
        }
    }

    void OnDeSelect()
    {
        anim.SetBool("Move", false);
        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }
    void OnSelect()
    {
        anim.SetBool("Move", true);
        sr.color = new Color(1f, 1f, 1f);
    }
}
