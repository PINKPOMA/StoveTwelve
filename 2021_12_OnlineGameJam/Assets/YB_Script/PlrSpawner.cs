using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlrSpawner : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public GameObject Plr;
    private void Start()
    {
        Plr = Instantiate(charPrefabs[(int) dataManager.instance.CurrentCharactor]);
        Plr.transform.position = transform.position;
    }
}
