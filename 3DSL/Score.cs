using TMPro;
using System.Collections;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score inst;
    
    public TextMeshProUGUI scoretext;
    public static float timer;
    public TextMeshProUGUI scorepaneltext;
    public TextMeshProUGUI timeattackscorepaneltext;
    public TextMeshProUGUI dashcorepaneltext;
    public  int score;
    public GameObject player;
    public TextMeshProUGUI timetext;
    public TextMeshProUGUI pausetext;

    public GameObject dashscorepanel;

    public void Awake()
    {
        if(!SceneManagement.dash)
        {
            timer = 60.00f;
        }
        else
        {
            timer = 0f;
        }
        inst = this;
    }

    void Start()
    {
        score = 0;
        if (SceneManagement.classic)
        {
            timetext.enabled = false;
        }
        else
        {
            timetext.enabled = true;
        }

        if(SceneManagement.dash)
        {
            score = 500;
        }
    }


    void FixedUpdate()
    {
        timetext.text = timer.ToString("F2") + "s";
        if(timer>=0 && SceneManagement.timeattack)
        {
            timer = timer - Time.deltaTime;
        }

        if(SceneManagement.dash)
        {
            if(obscollider.outcount<3  && score<=500)
            {
                timer = timer + Time.deltaTime;
            }
         
        }

        if (timer <= 0)
        {
            obscollider.isalive = false;
        }

        if ((Input.touchCount > 0) && Time.frameCount%15 == 0 && obscollider.isalive && !SceneManagement.dash)
        {
            score++;
        }
        if ((Input.touchCount > 0) && Time.frameCount % 15 == 0 && obscollider.isalive && SceneManagement.dash)
        {
            score--;
        }

          scoretext.text = score.ToString();
        if(SceneManagement.classic)
        {
            scorepaneltext.text = score.ToString();
            pausetext.text = scorepaneltext.text;
            if(score>=100)
            {
                playgamecontroller.instance.UnlockAchievement(GPGSIds.achievement_classic100);
            }
            if (score >= 500)
            {
                playgamecontroller.instance.UnlockAchievement(GPGSIds.achievement_classic500);
            }
            if (score >= 1000)
            {
                playgamecontroller.instance.UnlockAchievement(GPGSIds.achievement_classic1000);
            } 
            
            if (score > PlayerPrefs.GetInt("highscore", 0))
            {
                PlayerPrefs.SetInt("highscore", score);
                
            }
        }

        if(SceneManagement.timeattack)
        {
            timeattackscorepaneltext.text = score.ToString();
            pausetext.text = timeattackscorepaneltext.text;
            if(score>=300)
            {
                playgamecontroller.instance.UnlockAchievement(GPGSIds.achievement_time300);
            }
            if (score > PlayerPrefs.GetInt("timescore", 0))
            {
                PlayerPrefs.SetInt("timescore", score);
            }
        }

        if(SceneManagement.dash)
        {
            dashcorepaneltext.text = timetext.text;
            pausetext.text = dashcorepaneltext.text;
            if (score<=0)
            {
                obscollider.isalive = false;
                player.transform.position =player.transform.position + new Vector3(0, 0, 1f);
                StartCoroutine(waitmethod());
            }
           

        }

    }


    IEnumerator waitmethod()
    {
        yield return new WaitForSeconds(2);
        Adscontroller.showads();
        if (timer > PlayerPrefs.GetFloat("dashscore", 0))
        {

            PlayerPrefs.SetFloat("dashscore", timer);
        }
        dashscorepanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
