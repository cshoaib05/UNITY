using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conroller : MonoBehaviour
{
    public GameObject startpanel;
    public GameObject Gameover;
    public GameObject records;

    public TextMeshProUGUI highbest;
    public TextMeshProUGUI besttime;


    private void Awake()
    {
        highbest.text = PlayerPrefs.GetInt("highest").ToString();
        besttime.text = PlayerPrefs.GetString("time","00:00");
    }


    public void exit()
    {
        Application.Quit();
    }

    public void gameStart()
    {
        startpanel.SetActive(false);
       
    }

    public void retry()
    {
        SceneManager.LoadScene(0);
        
     }

    public void Showrecords()
    {
        records.SetActive(true);
    }

    public void hiderecords()
    {
        records.SetActive(false);
    }



}
