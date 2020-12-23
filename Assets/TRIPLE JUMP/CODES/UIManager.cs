using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject startPanel;
    public GameObject gamePanel;
    [Header("GAMEOVER")]
    public GameObject gameOverPanel;
    public GameObject failedText;
    public GameObject completeText;
    public GameObject retryBtn;
    public GameObject nextBtn;
    public Image levelProgBar;
    public TextMeshProUGUI levelText;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
        levelProgBar.fillAmount = (float)ObstacleManager.instance.obstaclePassed / (float)ObstacleManager.instance.obstacleMaxInLevel;
        levelText.text="Level " + (GameManager.instance.levelNumber + 1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBtn()
    {
        GameManager.instance.startGame = true;
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void RetryBtn()
    {
        GameManager.instance.totalFailNumber = PlayerPrefs.GetInt(GameManager.instance.totalFailedKey,0);
        GameManager.instance.totalFailNumber++;
        PlayerPrefs.SetInt(GameManager.instance.totalFailedKey, GameManager.instance.totalFailNumber);
        if (GameManager.instance.totalFailNumber % 2 ==0)
        {
            if(ADManager.instance.IsInterstitialReady())
                ADManager.instance.ShowInterstitialAd();//UNITY
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void NextBtn()
    {
        GameManager.instance.levelNumber++;//store
        PlayerPrefs.SetInt(GameManager.instance.levelKey,GameManager.instance.levelNumber);

        if (GameManager.instance.levelNumber % 2 == 0)
        {
            if (ADManager.instance.IsRewardedReady())
            {
                ADManager.instance.ShowRewardedAd();//UNITY
            }
            else if(ADManager.instance.IsInterstitialReady())                 
            {
                ADManager.instance.ShowInterstitialAd();//UNITY
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
