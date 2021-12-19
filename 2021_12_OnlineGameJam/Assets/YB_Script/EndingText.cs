using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingText : MonoBehaviour
{
    private GameManager _gameManager;

    public Text EndingTxt;

    private void Awake()
    {
        EndingTxt.text = "스마일게이트 점프! 페스티벌을" + Environment.NewLine +
                        "플레이 해주셔서 감사합니다!" + Environment.NewLine + Environment.NewLine +
                         "-제작-" + Environment.NewLine + Environment.NewLine +
                         "기획" + Environment.NewLine +
                         "김진성" + Environment.NewLine + Environment.NewLine +
                         "아트" + Environment.NewLine +
                         "살바도르달리&피카소" + Environment.NewLine + Environment.NewLine + 
                         "프로그래밍" + Environment.NewLine + 
                         "고수처럼" +Environment.NewLine + 
                         "이원석" + Environment.NewLine + 
                         "최유빈" + Environment.NewLine + Environment.NewLine +
                         
                         "-게임 통계-" + Environment.NewLine + Environment.NewLine + 
                         "태초마을" + Environment.NewLine + PlayerPrefs.GetInt("ReturnHome", 0) + "회 돌아감" + Environment.NewLine +
                         Environment.NewLine + "클리어 시간" + Environment.NewLine +  $"{EndingEnd.time/60} 분 {EndingEnd.time%60} 초" +
                         Environment.NewLine + Environment.NewLine + "점프 횟수" +
                         Environment.NewLine + $"{ PlayerPrefs.GetInt("Jump", 0)}" + "회";
    }
}
