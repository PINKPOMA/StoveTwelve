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
        EndingTxt.text = "스마일게이트 점프! 페스티벌을" + System.Environment.NewLine + "플레이 해주셔서 감사합니다!" +
                         System.Environment.NewLine + System.Environment.NewLine +
                         "-제작-" + System.Environment.NewLine + System.Environment.NewLine + "기획" +
                         System.Environment.NewLine + "김진성" + System.Environment.NewLine + System.Environment.NewLine +
                         "아트" + System.Environment.NewLine + "살바도르달리&피카소" + System.Environment.NewLine +
                         System.Environment.NewLine + "프로그래밍" + System.Environment.NewLine + "고수처럼" +
                         System.Environment.NewLine + "이원석" + System.Environment.NewLine + "최유빈" +
                         System.Environment.NewLine + System.Environment.NewLine +
                         "-게임 통계-" + System.Environment.NewLine + System.Environment.NewLine + "태초마을" +
                         System.Environment.NewLine + "n" + "회 돌아감" + System.Environment.NewLine +
                         System.Environment.NewLine + "클리어 시간" + System.Environment.NewLine + "n" + "분" +
                         System.Environment.NewLine + System.Environment.NewLine + "점프 횟수" +
                         System.Environment.NewLine + "n" + "회";
    }
}
