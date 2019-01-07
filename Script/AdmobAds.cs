using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class admobads : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;
    public GameObject outpanel;
    public GameObject scorepnel;
    public static bool revivedone;
    public static bool ads;

    private void Awake()
    {
        MobileAds.Initialize("ca-app-pub-2133244140433100~8772992886");
    }

    public void Start()
    {

        revivedone = false;
        ads = false;
        //MobileAds.Initialize("ca-app-pub-8230490726216835~6310173581");

        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        this.RequestRewardBasedVideo();
    }

   
     public void RequestRewardBasedVideo()
     {

        string adUnitId = "ca-app-pub-2133244140433100/1856176843";
       //string adUnitId = "ca-app-pub-8230490726216835/9930688541";

        AdRequest request = new AdRequest.Builder().Build();

        rewardBasedVideo.LoadAd(request, adUnitId);
     }

    public void UserOptToWatchAd()
    {

        if (!rewardBasedVideo.IsLoaded())
        {
            MyDelay(6);
            scorepnel.SetActive(true);

        }
        else
        {
            rewardBasedVideo.Show();
            this.RequestRewardBasedVideo();
        }
    }

    

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }



    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }


   
    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }





    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        outpanel.SetActive(false);
        revivedone = true;
        Time.timeScale = 1f;

    }

 

    public static void MyDelay(int seconds)
    {
        DateTime dt = DateTime.Now + TimeSpan.FromSeconds(seconds);

        do { } while (DateTime.Now < dt);
    }

}


