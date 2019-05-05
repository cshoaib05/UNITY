using System;
using TMPro;
using UnityEngine;

public class TextAnimeController : MonoBehaviour
{
    public static  TextAnimeController animeInst;
    public Animator textanime;
    public Animator textanimenear;

    public TextMeshProUGUI text;
    


    private void Awake()
    {
        animeInst = this;   
    }

    public void AnimePlay(int index)
    {
        if (index == 0) { textanimenear.Play("textAnime"); }
        else
        {
            if (index == 1) { text.text = "Short Streak  +10"; }
            if (index == 2) { text.text = "Long Streak  +15"; }
            if (index == 3) { text.text = "Super Streak  +20"; }
            if (index == 4) { text.text = "Mega Streak  +25"; }
            if (index == 5) { text.text = "Ultra Streak  +30"; }

            textanime.Play("textAnime");
        }


    }

}
