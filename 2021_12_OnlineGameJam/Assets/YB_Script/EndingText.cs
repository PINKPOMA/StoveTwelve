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
        EndingTxt.text = "�����ϰ���Ʈ ����! �佺Ƽ����" + System.Environment.NewLine + "�÷��� ���ּż� �����մϴ�!" +
                         System.Environment.NewLine + System.Environment.NewLine +
                         "-����-" + System.Environment.NewLine + System.Environment.NewLine + "��ȹ" +
                         System.Environment.NewLine + "������" + System.Environment.NewLine + System.Environment.NewLine +
                         "��Ʈ" + System.Environment.NewLine + "��ٵ����޸�&��ī��" + System.Environment.NewLine +
                         System.Environment.NewLine + "���α׷���" + System.Environment.NewLine + "���ó��" +
                         System.Environment.NewLine + "�̿���" + System.Environment.NewLine + "������" +
                         System.Environment.NewLine + System.Environment.NewLine +
                         "-���� ���-" + System.Environment.NewLine + System.Environment.NewLine + "���ʸ���" +
                         System.Environment.NewLine + "n" + "ȸ ���ư�" + System.Environment.NewLine +
                         System.Environment.NewLine + "Ŭ���� �ð�" + System.Environment.NewLine + "n" + "��" +
                         System.Environment.NewLine + System.Environment.NewLine + "���� Ƚ��" +
                         System.Environment.NewLine + "n" + "ȸ";
    }
}
