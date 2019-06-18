using UnityEngine.Advertisements;
using UnityEngine;

public class Adscontroller : MonoBehaviour
{
    private string gameid;

    private void Start()
    {
        gameid = "3190890";
        Advertisement.Initialize(gameid);
    }


    public static void showads()
    {
        if(Advertisement.IsReady("video"))
        {
            Advertisement.Show();
        }

    }
}
