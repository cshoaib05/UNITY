using System;
using TMPro;
using UnityEngine;

public class TextAnimeController : MonoBehaviour
{
    public static  TextAnimeController animeInst;
    public Animator textanime;
    public TextMeshProUGUI text;
    


    private void Awake()
    {
        animeInst = this;   
    }

    public void AnimePlay(int index)
    {
        if (index == 0) { text.text = "Near Miss  +10"; }

        if (index == 1) { text.text = "Short Streak  +10"; }
        if (index == 2) { text.text = "Long Streak  +15"; }
        if (index == 3) { text.text = "Super Streak  +20"; }
        if (index == 4) { text.text = "Super Streak  +20"; }
        if (index == 5) { text.text = "Super Streak  +20"; }

         textanime.Play("textAnime");
    }

}
