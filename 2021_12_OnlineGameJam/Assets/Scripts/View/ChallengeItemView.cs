using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChallengeItemView : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI value;

    public string Name
    {
        set => name.text = value;
    }
    public string Value
    {
        set => this.value.text = value;
    }

    public void Clear(bool isClear)
    {
        if(isClear)
        {
            name.color = Color.green;
            value.color = Color.green;
        }
    }

}
