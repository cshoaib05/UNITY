using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine;

public class playgamecontroller : MonoBehaviour
{
    void Start()
    {
        Authenticate();
    }

    void Authenticate()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if(success==true)
            {
                Debug.Log("success");
            }
        });
    }
    public static void posttoleaderboard(int score)
    {

        Social.ReportScore(score, GPGSIds.leaderboard_highscore,(bool success)=>
        {
            if(success)
            {
                Debug.Log("success");
            }
        });
    }

    public  void showleaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_highscore);
    }
}
