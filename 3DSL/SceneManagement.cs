using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class SceneManagement : MonoBehaviour
{

    public GameObject pausepanel;
    public TextMeshProUGUI[] statstext;

    private void Start()
    {
        statstext[0].text = PlayerPrefs.GetInt("highscore").ToString();
        statstext[1].text = PlayerPrefs.GetInt("streaks").ToString();
        statstext[2].text = PlayerPrefs.GetInt("nearmiss").ToString();
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



}
