using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    public void Loadthescene(int name)
    {
        playermov.speed = 0.2f;
        Time.timeScale = 1;
        SceneManager.LoadScene(name);

    } 

    public void Quit()
    {
        Application.Quit();
    }
}
