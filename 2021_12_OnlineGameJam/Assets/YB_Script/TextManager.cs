using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text text;
    public void Awake()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    public void On()
    {
        StartCoroutine(FadeTextToFullAlpha());
    }

    public void Off()
    {
        StartCoroutine(FadeTextToZero());
    }
    
    public IEnumerator FadeTextToZero()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime));
            yield return null;
        }
    }
    public IEnumerator FadeTextToFullAlpha() 
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime));
            yield return null;
        }
    }   
}
