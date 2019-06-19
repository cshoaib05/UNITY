using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SceneManagement : MonoBehaviour
{

    public GameObject pausepanel;
    public TextMeshProUGUI[] statstext;
   public TextMeshProUGUI vibratetext;
   public TextMeshProUGUI MusicText;
    

    public static bool timeattack;
    public static bool classic;
    public static bool dash;

    private void Start()
    {

        statstext[0].text = PlayerPrefs.GetInt("highscore").ToString();
        statstext[1].text = PlayerPrefs.GetInt("streaks").ToString();
        statstext[2].text = PlayerPrefs.GetInt("nearmiss").ToString();

        if(PlayerPrefs.GetInt("vibrate")==1)
        {
            vibratetext.text = "Vibrate : ON";
        }
        else
        {
            vibratetext.text = "Vibrate : OFF";
        }

        if (PlayerPrefs.GetInt("music") == 1)
        {
            MusicText.text = "Music : ON";
        }
        else
        {
            MusicText.text = "Music : OFF";
        }
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }


    public void Loadthescene(int name)
    {
        FindObjectOfType<AudioManager>().Play("click");
        Time.timeScale = 1;
        Nearmiss.neaarmisscount = 0;
        SceneManager.LoadScene(name);
    } 

    public void pause()
    {
        FindObjectOfType<AudioManager>().Play("click");
        Time.timeScale = 0;
        obscollider.isalive = false;
        pausepanel.SetActive(true);
    }

    public void resume()
    {
        FindObjectOfType<AudioManager>().Play("click");
        obscollider.isalive = true;
        pausepanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("click");
        Application.Quit();
    }

    public void loadclassic()
    {
        FindObjectOfType<AudioManager>().Play("click");
        Loadthescene(1);
        timeattack = false;
        dash = false;
        classic = true;
    }
 
    public void loadtimeattack()
    {
        FindObjectOfType<AudioManager>().Play("click");
        Loadthescene(1);
        timeattack = true;
        classic = false;
        dash = false;
     }

    public void loaddash()
    {
        FindObjectOfType<AudioManager>().Play("click");
        Loadthescene(1);
        obscollider.outcount = 0;
        timeattack = false;
        classic = false;
        dash = true;
    }





    public void vibratebutton()
    {
        FindObjectOfType<AudioManager>().Play("click");
        if (obscollider.vibrate == 1)
        {
            obscollider.vibrate = 0;
            vibratetext.text = "Vibrate : OFF";

        }
        else
        {
            obscollider.vibrate = 1;
            vibratetext.text = "Vibrate : ON";
        }

        PlayerPrefs.SetInt("vibrate", obscollider.vibrate);
    }


    public void Musicbutton()
    {
        FindObjectOfType<AudioManager>().Play("click");
        if (AudioManager.music == 1)
        {
            AudioManager.music = 0;
            MusicText.text = "Music : OFF";

        }
        else
        {
            AudioManager.music = 1;
            MusicText.text = "Music : ON";
        }

        PlayerPrefs.SetInt("music", AudioManager.music);
    }
}
