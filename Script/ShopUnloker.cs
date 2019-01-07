using TMPro;
using UnityEngine;

public class customizer : MonoBehaviour
{
    [SerializeField] GameObject[]  players;
    public static int pindex,selectedplayer;

    [SerializeField] GameObject selectbttn;
    [SerializeField] GameObject lockbttn;
    [SerializeField] GameObject imagelock;

    private int[] points = {0,10000,20000,30000,50000,70000};
    public TextMeshProUGUI text;
    public TextMeshProUGUI unlockscore;
    

    private void Start()
    {
        int i=0;
        pindex = 0;
        selectedplayer = 0;
        foreach(int a in points)
        {
            if(PlayerPrefs.GetInt("highscore")>a)
            {
                i++;
            }
        }
        PlayerPrefs.SetInt("unlock", i);
    }

    public void right()
    {
        pindex++;
        pindex = Mathf.Clamp(pindex, 0, 5);
        for (int i = 0; i < 6; i++)
        {
            if (i == pindex) { players[pindex].SetActive(true); }
            else { players[i].SetActive(false); }
        }

        if (PlayerPrefs.GetInt("highscore") >= points[pindex])
        {
            lockbttn.SetActive(false);
            selectbttn.SetActive(true);
            imagelock.SetActive(false);
            if (selectedplayer == pindex) { text.text = "SELECTED"; }
            else { text.text = "SELECT"; }
        }
        else
        {
            lockbttn.SetActive(true);
            imagelock.SetActive(true);
            unlockscore.text = "unlock at "+ points[pindex].ToString()+" score";
            selectbttn.SetActive(false);
        }

        FindObjectOfType<AudioManager>().Play("click");
    }

    public void left()
    {
        pindex--;
        pindex = Mathf.Clamp(pindex, 0, 5);
        for (int i = 0; i < 6; i++)
        {
            if (i == pindex) { players[pindex].SetActive(true); }
            else { players[i].SetActive(false); }
        }
        if (selectedplayer == pindex) { text.text = "SELECTED"; }
        else { text.text = "SELECT"; }

        if (PlayerPrefs.GetInt("highscore") >= points[pindex])
        {
            lockbttn.SetActive(false);
            imagelock.SetActive(false);
            selectbttn.SetActive(true);
            if (selectedplayer == pindex) { text.text = "SELECTED"; }
            else { text.text = "SELECT"; }
        }
        else
        {
            lockbttn.SetActive(true);
            imagelock.SetActive(true);
            unlockscore.text = "unlock at " + points[pindex].ToString() + " score";
            selectbttn.SetActive(false);
        }

        FindObjectOfType<AudioManager>().Play("click");
    }

    public void selectplayer()
    {
        selectedplayer = pindex;  
        text.text = "SELECTED";
        FindObjectOfType<AudioManager>().Play("select");
    }


}
