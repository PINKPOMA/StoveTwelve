using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingEnd : MonoBehaviour
{
    public static int time;
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Title");
    }
}
