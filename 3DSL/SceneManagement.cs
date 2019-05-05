using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{

    public void Loadthescene(int name)
    {
        playermov.speed = 0.2f;
        SceneManager.LoadScene(name);
    } 

    public void Quit()
    {
        Application.Quit();
    }
}
