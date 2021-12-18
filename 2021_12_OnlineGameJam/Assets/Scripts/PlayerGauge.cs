using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGauge : MonoBehaviour
{
    public Player player;
    public Image fillImage;


    public void SetFill(float fill)
	{
        fillImage.fillAmount = fill;
	}
}
