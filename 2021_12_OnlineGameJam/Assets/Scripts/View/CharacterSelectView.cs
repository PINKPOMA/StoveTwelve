using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectView : MonoBehaviour
{
    public Image image;
    public void OnCharacterSelect(int number)
    {
        Singleton.Instance.PlayerNumber = number;

        var seq = DOTween.Sequence();
        seq.Append(image.DOFade(1, 1.5f).From(0));
        seq.OnComplete(() => { SceneManager.LoadScene("Game"); });

    }
}
