using UnityEngine.Advertisements;
using UnityEngine;
public class Adscontroller : MonoBehaviour
{
    private string gameid;
    public static int countads;
    private void Start()
    {
        countads = 0;
        gameid = "3190890";
        Advertisement.Initialize(gameid);
    }


    public static void showads()
    {
        countads++;
        if(Advertisement.IsReady("video") && countads%3==0)
        {
           // Advertisement.Show();
        }

    }
}
