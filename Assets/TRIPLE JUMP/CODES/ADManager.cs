using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class ADManager : MonoBehaviour, IUnityAdsListener
{
    public static ADManager instance;
    public static string sessionIDKey = "SessionKey";
    public int sessionID;
    [Header("Unity Ads settings")]
    //public string gameId_ios;
    public string gameId_android;
    public bool testMode;

    //private string gameId = "3886365"; // Set in Start()
    private const string placementId_interstitial = "video";
    private const string placementId_rewarded = "rewardedVideo";
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        sessionID = PlayerPrefs.GetInt(sessionIDKey);
        // Initialize Unity Ads
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId_android, testMode);
    }

    #region UNITY AD
    // Functions used to show an ad to the player
    public void ShowInterstitialAd() => StartCoroutine(WaitForAd(placementId_interstitial));
    public void ShowRewardedAd() => StartCoroutine(WaitForAd(placementId_rewarded));

    private IEnumerator WaitForAd(string placementId)
    {

        // Wait for an ad to be ready
        while (!Advertisement.IsReady(placementId)) yield return null;

        Advertisement.Show(placementId);
    }
    public bool IsInterstitialReady()
    {
        return Advertisement.IsReady(placementId_interstitial);
    }
    public bool IsRewardedReady()
    {
        return Advertisement.IsReady(placementId_rewarded);
    }
    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        // Optional code to be executed when an ad is available
        // (e.g. notify the player with a sound or some icon...)
    }
    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
        // Optional code to be executed when an ad starts 
        // (e.g. pause the game, save progress...)
    }
    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
        // Optional code to be executed when an ad starts 
        // (e.g. log the error to the console, pop up a ui window to notify the player...)
    }
    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Only evaluate show result if the ad was a rewarded one
        if (placementId == placementId_rewarded)
        {
            switch (showResult)
            {
                case ShowResult.Finished:
                    // Reward the player
                    //continue game. set score, health etc.
                    Time.timeScale = 1;
                    SceneManager.LoadScene("SampleScene");
                    //StartCoroutine(UIManager.instance.ReviveShockWaveRoutine());
                    //StartCoroutine(GameManager.instance.ShockWaveSlowmo());

                    //rewardDisplayText.text = "Rewards: " + rewardsGiven.ToString();
                    Debug.Log("finished.");
                    break;
                case ShowResult.Skipped:
                    Debug.Log("The player was not rewarded for skipping the ad.");
                    break;
                case ShowResult.Failed:
                    Debug.LogWarning("The ad did not finish due to an error.");
                    break;
            }
        }
        if (placementId == placementId_interstitial)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    #endregion
}
