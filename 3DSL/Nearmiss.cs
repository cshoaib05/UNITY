using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nearmiss : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("obstacles"))
        {
            TextAnimeController.animeInst.AnimePlay(0);

            Score.inst.score = Score.inst.score + 10;
        }
    }
}
