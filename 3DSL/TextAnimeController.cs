﻿using System;
using TMPro;
using UnityEngine;

public class TextAnimeController : MonoBehaviour
{
    public static  TextAnimeController animeInst;
    public Animator textanime;
    public Animator textanimenear;
    public TextMeshProUGUI streaktext;
    public TextMeshProUGUI text;

    private int streakcount;

    private void Awake()
    {
        animeInst = this;
    }
    private void Start()
    {
        streakcount = 0;
    }

    public void AnimePlay(int index)
    {
        if (index == 0) { textanimenear.Play("textAnime"); }
        else
        {
            if (index == 1) { text.text = "Short Streak  +10";  }
            if (index == 2) { text.text = "Streak  +15"; }
            if (index == 3) { text.text = "Long Streak  +20"; }
            if (index == 4) { text.text = "Super Streak  +25"; }
            if (index == 5) { text.text = "Mega Streak  +30"; }
            if (index == 6) { text.text = "Ultra Streak  +35"; }
            if (index == 7) { text.text = "OMG Streak  +40"; }
            streaktext.text = "Streak: " + streakcount++.ToString();
            textanime.Play("textAnime");
        }


    }

}
