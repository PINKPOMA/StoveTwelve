using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class MainTitlePresenter : MonoBehaviour
{
    public Image image;
    public int count = 0;
    public GameObject[] test;
    public void OnTItleClick()
    {
        count += 1;
        if (count >= 10)
        {
            test[0].SetActive(true);
        }
        if (count >= 15)
        {
            test[1].SetActive(true);
        }


    }
    public void OnStart(int type)
    {
        Singleton.Instance.GameType = (GameType)type;
        image.DOFade(1, 1).From(0).OnComplete(() => SceneManager.LoadScene("SelectPlr"));
    }

}
