using System.Collections;
using TMPro;
using UnityEngine;

public class TextAnimeController : MonoBehaviour
{
    public static  TextAnimeController animeInst;
    public Animator textanime;
    public Animator textanimenear;
    public TextMeshProUGUI streaktext;
    public TextMeshProUGUI timeattackstreaktext;
    public TextMeshProUGUI dashstreaktext;

    public TextMeshProUGUI streaktext2;
    public GameObject timeattackpanel;
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


    private void  FixedUpdate()
    {
        if(Score.timer>0 && Score.timer<0.1 && SceneManagement.timeattack)
        {
            AnimePlay(8);
        }
    }

    public void AnimePlay(int index)
    {
        if (index == 0) { textanimenear.Play("textAnime"); }
        else
        {
            if (index == 1) { text.text = "Short Streak  +10";  }
            if (index == 2) { text.text = "Streak  +15"; }
            if (index == 3) { text.text = "Long Streak  +20"; }
            if(index==3)
            {
                playgamecontroller.instance.incrementalAchievement(GPGSIds.achievement_streak10, 1);
                playgamecontroller.instance.incrementalAchievement(GPGSIds.achievement_streak50, 1);
                playgamecontroller.instance.incrementalAchievement(GPGSIds.achievement_streak100, 1);
            }
            if (index == 4) { text.text = "Super Streak  +25"; }
            if (index == 5) { text.text = "Mega Streak  +30"; }
            if (index == 6) { text.text = "Ultra Streak  +35"; }
            if (index == 7) { text.text = "OMG Streak  +40"; }
            if (index == 7)
            {
                playgamecontroller.instance.incrementalAchievement(GPGSIds.achievement_omg_5, 20);
                playgamecontroller.instance.UnlockAchievement(GPGSIds.achievement_omg);
            }
            streaktext.text = "Streak: " + streakcount++.ToString();
            streaktext2.text = streaktext.text;
            timeattackstreaktext.text = streaktext.text;
            dashstreaktext.text = streaktext.text;
            textanime.Play("textAnime");

        }
 

        if (index == 8)
        {
            text.text = "Times Up !! ";
            textanime.Play("textAnime");
            StartCoroutine(waitmethod());
        }
        if (streakcount > PlayerPrefs.GetInt("streaks", 0))
        {
            PlayerPrefs.SetInt("streaks", streakcount);
        }


    }

    IEnumerator waitmethod()
    {
        yield return new WaitForSeconds(1f);
        Adscontroller.showads();
        timeattackpanel.SetActive(true);
    }



}
