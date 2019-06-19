using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Animationcontroller : MonoBehaviour
{
    public Animator iconanim;
    public GameObject iconswhite;
    public GameObject mainbutton;
    public GameObject[] panels;
    public Image[] iconsimage;
    private Color tempcolor;

    public GameObject statspanel;
    public GameObject statspanel2;


    public TextMeshProUGUI statsclassic;
    public TextMeshProUGUI statstimeattack;
    public TextMeshProUGUI stasdash;
    public AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        statsclassic.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        statstimeattack.text = PlayerPrefs.GetInt("timescore", 0).ToString();
        stasdash.text = PlayerPrefs.GetFloat("dashscore", 0).ToString();
    }

    public void Playbutton()
     {
        audioManager.Play("main");
        mainbutton.SetActive(false);
        iconswhite.SetActive(true);
        iconanim.Play("IconAnim");
        showimagewhite(0);
        panels[0].SetActive(true);
        
    }
    
    public void Profilebutton()
    {
        audioManager.Play("main");
        mainbutton.SetActive(false);
        iconswhite.SetActive(true);
        iconanim.Play("IconAnim");
        showimagewhite(1);
        panels[1].SetActive(true);
    }


    public void Settbutton()
    {
        audioManager.Play("main");
        mainbutton.SetActive(false);
        iconswhite.SetActive(true);
        iconanim.Play("IconAnim");
        showimagewhite(2);
        panels[2].SetActive(true);
    }

    public void exitbutton()
    {
      audioManager.Play("main");
        mainbutton.SetActive(false);
        iconswhite.SetActive(true);
        iconanim.Play("IconAnim");
        showimagewhite(3);
        panels[3].SetActive(true);
    }

    public void playicon()
    {
        audioManager.Play("click");
        Panelshow(0);
        showimagewhite(0);

    }

    public void profileicon()
    {
        audioManager.Play("click");
        Panelshow(1);
        showimagewhite(1);
    }

    public void settingicon()
    {
        audioManager.Play("click");
        Panelshow(2);
        showimagewhite(2);
    }

    public void  exiticon()
    {
        audioManager.Play("click");
        Panelshow(3);
        showimagewhite(3);
    }


    private void Panelshow(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == index)
            { 
                panels[i].SetActive(true);

            }
            else
            {
                panels[i].SetActive(false);
            }
        }
    }

    public void showimagewhite(int index1)
    {
        for (int i = 0; i < iconsimage.Length; i++)
        {
            if (i == index1)
            {
                tempcolor = iconsimage[i].color;
                tempcolor.a = 1f;
                iconsimage[i].color = tempcolor;

            }
            else
            {
                tempcolor = iconsimage[i].color;
                tempcolor.a = 0.5f;
                iconsimage[i].color = tempcolor;
            }
        }
    }

    public void cancelexit()
    {
        audioManager.Play("click");
        Panelshow(4);
        iconswhite.SetActive(false);
    }


    public void showhigh()
    {
        audioManager.Play("click");
        iconswhite.SetActive(false);
        panels[1].SetActive(false);
        statspanel.SetActive(true);
    }

    public void hidehigh()
    {
        audioManager.Play("click");
        statspanel.SetActive(false);
        mainbutton.SetActive(true);
    }

    public void showstats()
    {
        audioManager.Play("click");
        iconswhite.SetActive(false);
        panels[1].SetActive(false);
        statspanel2.SetActive(true);
    }

    public void hidestats()
    {
        audioManager.Play("click");
        statspanel2.SetActive(false);
        mainbutton.SetActive(true);
    }
}
