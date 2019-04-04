using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationcontroller : MonoBehaviour
{
    public Animator iconanim;
    public GameObject iconswhite;
    public GameObject mainbutton;
    public GameObject[] panels;

    
    public void Playbutton()
     {
        mainbutton.SetActive(false);    
        iconswhite.SetActive(true);
        iconanim.Play("whiteicon");
        panels[0].SetActive(true);
    }

    public void Profilebutton()
     {
        mainbutton.SetActive(false);    
        iconswhite.SetActive(true);
        iconanim.Play("whiteicon");
        panels[1].SetActive(true);
    }


    public void Settbutton()
     {
        mainbutton.SetActive(false);    
        iconswhite.SetActive(true);
        iconanim.Play("whiteicon");
        panels[2].SetActive(true);
    }

    public void playicon()
    {
        endis(0);
    }

    public void profileicon()
    {
        endis(1);
    }

    public void settingicon()
    {
        endis(2);
    }

    public void  exiticon()
    {

    }


    private void endis(int index)
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


}
