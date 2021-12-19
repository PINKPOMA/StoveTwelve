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
        EndingTxt.text = "�����ϰ���Ʈ ����! �佺Ƽ����" + Environment.NewLine +
                        "�÷��� ���ּż� �����մϴ�!" + Environment.NewLine + Environment.NewLine +
                         "-����-" + Environment.NewLine + Environment.NewLine +
                         "��ȹ" + Environment.NewLine +
                         "������" + Environment.NewLine + Environment.NewLine +
                         "��Ʈ" + Environment.NewLine +
                         "��ٵ����޸�&��ī��" + Environment.NewLine + Environment.NewLine + 
                         "���α׷���" + Environment.NewLine + 
                         "���ó��" +Environment.NewLine + 
                         "�̿���" + Environment.NewLine + 
                         "������" + Environment.NewLine + Environment.NewLine +
                         
                         "-���� ���-" + Environment.NewLine + Environment.NewLine + 
                         "���ʸ���" + Environment.NewLine + PlayerPrefs.GetInt("ReturnHome", 0) + "ȸ ���ư�" + Environment.NewLine +
                         Environment.NewLine + "Ŭ���� �ð�" + Environment.NewLine +  $"{EndingEnd.time/60} �� {EndingEnd.time%60} ��" +
                         Environment.NewLine + Environment.NewLine + "���� Ƚ��" +
                         Environment.NewLine + $"{ PlayerPrefs.GetInt("Jump", 0)}" + "ȸ";
    }
}
