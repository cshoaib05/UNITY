using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playercntroller : MonoBehaviour
{
    [SerializeField] GameObject[] playerss;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject options;
    [SerializeField] GameObject scorepanel;

    [SerializeField] GameObject loadingpanel;
    [SerializeField] Slider loadslid;
    public GameObject audiomanager;

    public Slider slider;
    public Toggle toggle;
    AudioSource source;

    private void Start()
    {
        source = playerss[customizer.selectedplayer].GetComponent<AudioSource>();
        for (int i = 0; i < 6; i++)
        {
            if (i == customizer.selectedplayer) { playerss[customizer.selectedplayer].SetActive(true); }
            else { playerss[i].SetActive(false); }
        }
        source.volume = PlayerPrefs.GetFloat("ingame",0.5f);
         slider.value = PlayerPrefs.GetFloat("ingame",1f);
    }

    public void musicgame()
    {
        source.volume = slider.value;
        PlayerPrefs.SetFloat("ingame", source.volume);
    }

    public void ClickPause()
    {
        Time.timeScale = 0f;
        Panel.SetActive(true);
        source.Pause();
    }

    public void ClickResume()
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);
        source.UnPause();
    }

    public void LoadPlay(int scene)
    {
        if (scene == 1)
        {
            CamMov.speed = 0.5f;
        }
        StartCoroutine(asloadasync(scene));
        Time.timeScale = 1f;
    }

    public void optionspanel()
    {
        Panel.SetActive(false);
        options.SetActive(true);
    }

    public void backbtn()
    {
        Panel.SetActive(true);
        options.SetActive(false);
    }

    public void scorepnl()
    {
        scorepanel.SetActive(true);
    }

    public void sfx()
    {
        AudioSource[] source = audiomanager.GetComponents<AudioSource>();

        foreach (AudioSource s in source)
        {
            if (s.name != "crash")
            {
                if (toggle.isOn)
                {
                    s.volume = 1;
                }
                else
                {
                    s.volume = 0;
                }
            }
        }
    }

    IEnumerator asloadasync(int scene)
    {
        loadingpanel.SetActive(true);
        AsyncOperation oper = SceneManager.LoadSceneAsync(scene);

        while (!oper.isDone)
        {
            float progress = Mathf.Clamp01(oper.progress / .9f);
            loadslid.value = progress;
            yield return null;
        }

    }
}
