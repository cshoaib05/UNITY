using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nearmiss : MonoBehaviour
{
    public static bool nearmiss;
    public static int neaarmisscount;

    private void Start()
    {
        neaarmisscount = 0;
        nearmiss = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("obstacles"))
        {
            TextAnimeController.animeInst.AnimePlay(0);
            nearmiss = true;
            playgamecontroller.instance.incrementalAchievement(GPGSIds.achievement_nearmiss100, 1);
            playgamecontroller.instance.incrementalAchievement(GPGSIds.achievement_nearmiss1000, 1);

            neaarmisscount++;
            if(SceneManagement.dash)
            {
                Score.inst.score = Score.inst.score - 10;
            }
            else
            {
                Score.inst.score = Score.inst.score + 10;
            }

        }

        if (neaarmisscount > PlayerPrefs.GetInt("nearmiss", 0))
        {
            PlayerPrefs.SetInt("nearmiss", neaarmisscount);
        }
    }
}
