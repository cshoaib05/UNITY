using System.Collections;
using System.Collections.Generic;
using UnityEngine.Sprites;
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




    public void Playbutton()
     {
        print(iconsimage.Length);
        mainbutton.SetActive(false);
        iconswhite.SetActive(true);
        iconanim.Play("IconAnim");
        showimagewhite(0);
        panels[0].SetActive(true);
        
    }
    
    public void Profilebutton()
     {
        mainbutton.SetActive(false);
        iconswhite.SetActive(true);
        iconanim.Play("IconAnim");
        showimagewhite(1);
        panels[1].SetActive(true);
    }


    public void Settbutton()
     {
        mainbutton.SetActive(false);
        iconswhite.SetActive(true);
        iconanim.Play("IconAnim");
        showimagewhite(2);
        panels[2].SetActive(true);
    }

    public void exitbutton()
    {
        mainbutton.SetActive(false);
        iconswhite.SetActive(true);
        iconanim.Play("IconAnim");
        showimagewhite(3);
        panels[3].SetActive(true);
    }

    public void playicon()
    {
        Panelshow(0);
        showimagewhite(0);

    }

    public void profileicon()
    {
        Panelshow(1);
        showimagewhite(1);
    }

    public void settingicon()
    {
        Panelshow(2);
        showimagewhite(2);
    }

    public void  exiticon()
    {
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
        Panelshow(4);
        iconswhite.SetActive(false);
    }

}
