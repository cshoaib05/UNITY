using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{

    public void Loadthescene(int name)
    {
        SceneManager.LoadScene(name);
        playermov.speed = 0.2f;
    } 

    public void Quit()
    {
        Application.Quit();
    }
}
