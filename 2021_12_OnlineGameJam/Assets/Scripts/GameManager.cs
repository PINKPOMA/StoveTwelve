using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    private void Awake()
    {
        SoundManager.Instance.PlayBGM("Game");
        player.OnJump += Player_OnJump; ;
        player.OnGroundFall += Player_OnGroundFall;
    }

    private void Player_OnJump(float obj)
    {
        var jump = 0;
        if(PlayerPrefs.HasKey("Jump"))
        {
            jump = PlayerPrefs.GetInt("Jump", 0);
        }
        PlayerPrefs.SetInt("Jump", jump + 1);
        Debug.Log(PlayerPrefs.GetInt("Jump", 0));
    }

    private void Player_OnGroundFall(float start, float end)
    {
        Debug.Log($"{end} {start}");
    }
    public UnityEngine.UI.Image image;
    public void GameClear()
    {
        Debug.Log("GameClear");
        var seq = DOTween.Sequence().SetUpdate(true);
        seq.Append(DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0, 2.5f).SetEase(Ease.InQuad));
        seq.Append(image.DOFade(1, 2.5f).SetDelay(1.5f).From(0));
        seq.OnComplete(() => SceneManager.LoadScene("Credit"));
    }
}
