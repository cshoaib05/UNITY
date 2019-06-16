using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score inst;
    
    public TextMeshProUGUI scoretext;
    public static float timer;
    public TextMeshProUGUI scorepaneltext;
    public TextMeshProUGUI timeattackscorepaneltext;
    public int score;

    public TextMeshProUGUI timetext;



    public void Awake()
    {
        timer = 60.00f;
        inst = this;
    }

    void Start()
    {


        score = 0;
        if (SceneManagement.timeattack)
        {
            timetext.enabled = true;
        }
        else
        {
            timetext.enabled = false;
        }
    }


    void FixedUpdate()
    {
        timetext.text = timer.ToString("F2") + "s";
        if(timer>=0)
        {
            timer = timer - Time.deltaTime;
        }

        if (timer <= 0)
        {
            obscollider.isalive = false;
        }

        if ((Input.touchCount > 0) && Time.frameCount%15 == 0 && obscollider.isalive)
        {
            score++;
        }

        scoretext.text = score.ToString();
        if(SceneManagement.classic)
        {
            scorepaneltext.text = score.ToString();
            if (score > PlayerPrefs.GetInt("highscore", 0))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }

        if(SceneManagement.timeattack)
        {
            timeattackscorepaneltext.text = score.ToString();
            if (score > PlayerPrefs.GetInt("timescore", 0))
            {
                PlayerPrefs.SetInt("timescore", score);
            }

        }





    }
}
