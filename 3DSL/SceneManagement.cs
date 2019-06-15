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
        Time.timeScale = 1;
        Nearmiss.neaarmisscount = 0;
        SceneManager.LoadScene(name);
    } 

    public void pause()
    {
        Time.timeScale = 0;
        pausepanel.SetActive(true);
    }

    public void resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void loadclassic()
    {

        Loadthescene(1);
        timeattack = false;
        classic = true;
    }
 
    public void loadtimeattack()
    {

        Loadthescene(1);
        timeattack = true;
        classic = false;
    }





    public void vibratebutton()
    {
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
