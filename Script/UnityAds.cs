using UnityEngine;
using UnityEngine.Advertisements;


public class ADscontroller : MonoBehaviour
{
    public GameObject outpanel;
    public static bool revivedone;
    public static bool ads;

    private void Start()
    {
        revivedone = false;
        ads = false;
        Advertisement.Initialize("2979993");

       
    }

    public static void requestadd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
          ads = true;
        }
    }

    public void showad()
    {
        ShowOptions so = new ShowOptions();
        so.resultCallback = rewardtheuser;
        Advertisement.Show("rewardedVideo",so);
    }

    private void rewardtheuser(ShowResult obj)
    {
       if(obj == ShowResult.Finished)
        {
            outpanel.SetActive(false);
            revivedone = true;
            Time.timeScale = 1f;
        }
    }

   
}
