using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Charactor
{
    Popo,Pepper,Kid,Peach
}
public class dataManager : MonoBehaviour
{
    public static dataManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            return;
        DontDestroyOnLoad(gameObject);
    }

    public Charactor CurrentCharactor;
}
