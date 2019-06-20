using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Collections;

public class SceneManagement : MonoBehaviour
{

    public GameObject pausepanel;
    public TextMeshProUGUI[] statstext;
   public TextMeshProUGUI vibratetext;
   public TextMeshProUGUI MusicText;
    public AudioManager audioManager;
    public GameObject loadpanel;
    public static bool timeattack;
    public static bool classic;
    public static bool dash;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
        
        audioManager.Play("click");
        Time.timeScale = 1;
        Nearmiss.neaarmisscount = 0;
        //SceneManager.LoadScene(name);
        StartCoroutine(asloadasync(name));
        //        SceneManager.LoadSceneAsync(name);
    } 
    

    public void pause()
    {
        audioManager.Play("click");
        Time.timeScale = 0;
        obscollider.isalive = false;
        pausepanel.SetActive(true);
    }

    public void resume()
    {
        audioManager.Play("click");
        obscollider.isalive = true;
        pausepanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        audioManager.Play("click");
        Application.Quit();
    }

    public void loadclassic()
    {
        audioManager.Play("click");
        Loadthescene(1);
        timeattack = false;
        dash = false;
        classic = true;
    }
 
    public void loadtimeattack()
    {
        audioManager.Play("click");
        Loadthescene(1);
        timeattack = true;
        classic = false;
        dash = false;
     }

    public void loaddash()
    {
        audioManager.Play("click");
        Loadthescene(1);
        obscollider.outcount = 0;
        timeattack = false;
        classic = false;
        dash = true;
    }





    public void vibratebutton()
    {
        audioManager.Play("click");
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
        audioManager.Play("click");
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

    IEnumerator asloadasync(int name)
    {
       loadpanel.SetActive(true);
        AsyncOperation oper = SceneManager.LoadSceneAsync(name);

        while (!oper.isDone)
        {
            float progress = Mathf.Clamp01(oper.progress / .9f);
            yield return null;
        }
    }


}
