using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{

    public void Loadthescene(int name)
    {
        SceneManager.LoadScene(name);
    } 

    public void Quit()
    {
        Application.Quit();
    }
}
