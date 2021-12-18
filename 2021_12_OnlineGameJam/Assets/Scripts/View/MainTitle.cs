using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MainTitle : MonoBehaviour
{
    public TextMeshProUGUI titleLogo;


    private void Awake()
    {
        titleLogo.DOFade(1, 1).From(0).SetDelay(1).SetEase(Ease.Flash,15,1).Loops();
    }
}
