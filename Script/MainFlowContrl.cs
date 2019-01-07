using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class MainContrl : MonoBehaviour
{
    [SerializeField] GameObject settingpanel;
    [SerializeField] GameObject storepanel;
    [SerializeField] GameObject scorepanel;
    [SerializeField] GameObject loadingpanel;
    [SerializeField] Slider   loadslid;


    public void LoadPlay(int scene)
    {
       
        if(scene == 1)
        {
            CamMov.speed = 0.5f;
        }
        StartCoroutine(asloadasync(scene));
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void exitgame()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("click");

    }

    public void settingbuttn(bool value)
    {
        settingpanel.SetActive(value);
        FindObjectOfType<AudioManager>().Play("click");

    }

    public void storebttn(bool value)
    {
      storepanel.SetActive(value);
        FindObjectOfType<AudioManager>().Play("click");

    }

    public void scorebttn(bool value)
    {
    scorepanel.SetActive(value);
    FindObjectOfType<AudioManager>().Play("click");
    }

   IEnumerator asloadasync(int scene)
    {
        loadingpanel.SetActive(true);
        AsyncOperation oper = SceneManager.LoadSceneAsync(scene);

        while(!oper.isDone)
        {
            float progress = Mathf.Clamp01(oper.progress / .9f);
            loadslid.value = progress;
            yield return null;
        }
       
    }
}
