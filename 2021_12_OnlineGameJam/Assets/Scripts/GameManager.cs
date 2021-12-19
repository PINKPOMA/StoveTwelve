using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject flag;

    public Player player;
    public float startTime;
    public TMPro.TextMeshProUGUI timerText;
    public GameObject gauge;

    private void Awake()
    {
        image.DOFade(0, 2.5f).SetDelay(1.5f).From(1);
        startTime = Time.deltaTime;
        if (Singleton.Instance.GameType == GameType.Easy || Singleton.Instance.GameType == GameType.SuperEasy)
        {
            gauge.SetActive(true);
        }
        else
        {
            gauge.SetActive(false);

        }


        flag.SetActive(false);
        SoundManager.Instance.PlayBGM("Game");
        player.OnJump += Player_OnJump; ;
        player.OnGroundFall += Player_OnGroundFall;
        player.OnBouns += Player_OnBouns; ;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
        if(Singleton.Instance.GameType == GameType.SuperEasy)
        {
            Save();
        }

        int total = Mathf.FloorToInt(Time.time - startTime);
        timerText.SetText($"{total/60:D2}:{total % 60:D2}");
    }


    private void Save()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (player.IsGround) //if(IsGround)
            {
                flag.SetActive(true);
                flag.transform.position = player.transform.position - new Vector3(0, 1, 0f);
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (player.IsGround) //if(IsGround)
            {
                player.transform.position = flag.transform.position + new Vector3(0, 1, 0f);
            }
        }
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


    private void Player_OnBouns()
    {
        PlayerPrefs.SetInt("Bound", PlayerPrefs.GetInt("Bound", 0) + 1);
        Debug.Log($"Bounds : {PlayerPrefs.GetInt("Bound", 0)}");
    }
    public GameObject text1;
    private void Player_OnGroundFall(float start, float end)
    {
        PlayerPrefs.SetInt("MaxFall", Mathf.Max(PlayerPrefs.GetInt("MaxFall"), Mathf.CeilToInt(start - end)));
        if (start>=25&&end <= -4f)
        {
            text1.SetActive(true);
            PlayerPrefs.SetInt("ReturnHome", PlayerPrefs.GetInt("ReturnHome", 0) + 1);
        }
    }
    public UnityEngine.UI.Image image;
    public void GameClear()
    {
        Debug.Log("GameClear");

        var clear = PlayerPrefs.GetInt("Clear", 0);
        PlayerPrefs.SetInt("Clear", clear + 1);

        var clearTime = Mathf.FloorToInt(Time.time - startTime);
        if(clearTime <=  PlayerPrefs.GetInt("ClearMinTime", clearTime))
        {
            PlayerPrefs.SetInt("ClearMinTime", clearTime);
        }

        EndingEnd.time = clearTime;
        Debug.Log(PlayerPrefs.GetInt("ClearMinTime", 0)); ;
        Debug.Log(PlayerPrefs.GetInt("Clear", 0)); ;

        var seq = DOTween.Sequence().SetUpdate(true);
        seq.Append(DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0, 1.5f).SetEase(Ease.OutExpo).SetUpdate(true));
        seq.Append(image.DOFade(1, 2.5f).SetDelay(1.5f).From(0));
        seq.OnComplete(() => { Time.timeScale = 1; SceneManager.LoadScene("Credit"); });


    }
}
