using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{

    public GameObject pausepanel;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    public void Loadthescene(int name)
    {
        Time.timeScale = 1;
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
