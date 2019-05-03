using System;
using TMPro;
using UnityEngine;

public class TextAnimeController : MonoBehaviour
{
    public static  TextAnimeController animeInst;
    public Animator textanime;
    public TextMeshProUGUI text;
    string[] textarray = new string[] { "Near Miss  +10",  "Short Streak  +10", "Long Streak  +15" };
    private void Awake()
    {
        animeInst = this;   
    }

    private void Start()
    {

    }

    public void AnimePlay(int index)
    {
        text.text = textarray[0];
         textanime.Play("textAnime");
    }

}
