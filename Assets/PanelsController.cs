using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class PanelsController : ScenesManager
{
    public GameObject pausePanel, deathPanel, winPanel;
    public ParticleSystem winEffect;

    public static bool panelsOn=false;

    private static int addCnt=1;

#if UNITY_IOS
    private string appId = "ca-app-pub-4962234576866611~8868101383";
    private string bannerId="ca-app-pub-4962234576866611/9967175032";
    private string intersitionalId="ca-app-pub-4962234576866611/3775556803";
#else
    private string appId = "ca-app-pub-4962234576866611~3401766686";
    private string bannerId="ca-app-pub-4962234576866611/7523230129";
    private string intersitionalId="ca-app-pub-4962234576866611/3751506073";
#endif

    private BannerView _bannerView;
    private InterstitialAd _interstitialAd;

    public WaterLevelController waterLevelController;

    void Start(){
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        MobileAds.Initialize(initStatus => {
          //CreateBannerView();
          //LoadBannerAd();
          LoadLoadInterstitialAd();
        });

        panelsOn=false;

        //TODO: remove(debug only)
        //PlayerPrefs.SetInt("level", Application.loadedLevel+1);
    }

    public void pause(){
        Time.timeScale=0;
        panelsOn=true;
        pausePanel.SetActive(true);

        if(addCnt%3==0){
            //showIntersitionalGoogleAd();
        }
        addCnt++;
    }

    public void resume(){
        Time.timeScale=1;
        Invoke(nameof(resetTimeScale), 0.5f);
        pausePanel.SetActive(false);
    }
    void resetTimeScale(){
        panelsOn=false;
    }

    public void setDeathPanelVisibility(bool visible){
        deathPanel.SetActive(visible);

        showIntersitionalGoogleAd();
        
        addCnt++;
    }

    public void setWinPanelVisibility(bool visible){
        winEffect.Play();
        winPanel.SetActive(visible);

        if(visible){
            PlayerPrefs.SetInt("level", Application.loadedLevel+1);

            if(waterLevelController){
                waterLevelController.OnPlayerWinHandle();
            }

            showIntersitionalGoogleAd();
        }
    }

    public void restart(){
        openScene(Application.loadedLevel);
    }

    public void next(){
        openScene(Application.loadedLevel+1);
    }

     //baner
    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyBannerView();
        }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
    }

    public void LoadBannerAd()
    {
        // create an instance of a banner view first.
        if(_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    public void LoadLoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
                _interstitialAd.Destroy();
                _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(intersitionalId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                    "with error : " + error);
                    return;
                }
                Debug.Log("Interstitial ad loaded with response : "
                            + ad.GetResponseInfo());
                _interstitialAd = ad;
            });
    }


      public bool showIntersitionalGoogleAd(){
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();

            return true;
        }
        else
        {
            return false;
        }
      }
}
