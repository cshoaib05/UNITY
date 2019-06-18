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
