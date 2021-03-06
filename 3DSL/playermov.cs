﻿using UnityEngine;
using TMPro;

public class playermov : MonoBehaviour
{
    public TextMeshProUGUI taptext;
    public GameObject nearmissobj;
    private Vector3 pos;
    float  t = 0f;
    public static float timetrack;
    public ParticleSystem streakeffect;
    public float streaktime;
    private bool isended;
    bool white;
    Color color= new Color(0,0,0,0.02f);

    void Start()
    {
        white = true;
        isended = false;
        streaktime = 0f;
        pos = transform.position;
        timetrack = 0f;
    }

    void Update()
    {
        if(taptext.enabled && white )
        {
            taptext.color = taptext.color - color;
            if(taptext.color.a<=0)
            {
                white = false;
            }
        }

        if (taptext.enabled && !white)
        {
            taptext.color = taptext.color + color;
            if (taptext.color.a >= 1)
            {
                white = true;
            }
        }


        if ( Nearmiss.nearmiss==true)
        {
            nearmissobj.SetActive(false);
        }

        int touchcountpress = Input.touchCount;


        if (touchcountpress > 0 )
        {
            touchcountpress = 1;
            taptext.enabled = false;
        }

        if (touchcountpress == 1  && obscollider.isalive)
        {
           
            Touch touch = Input.GetTouch(0);
            pos.z = Mathf.SmoothStep(pos.z, pos.z + 0.25f,t);
            t = t + 0.1f;
           t = Mathf.Clamp01(t);

            transform.position = pos;
            nearmissobj.SetActive(true);
            Nearmiss.nearmiss = false;
            if(touch.phase==TouchPhase.Began)
            {
                isended = false;
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                timetrack += Time.deltaTime;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isended = true;
            }

            if (timetrack > 1f && timetrack < 1f + Time.deltaTime)
            {
                if(SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 10;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 10;
                }
                 TextAnimeController.animeInst.AnimePlay(1);
            }

            if (timetrack > 2f && timetrack < 2f + Time.deltaTime)
            {
                if (SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 15;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 15;
                }
                TextAnimeController.animeInst.AnimePlay(2);
            }

            if (timetrack > 3f && timetrack < 3f + Time.deltaTime)
            {
                if (SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 20;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 20;
                }
                TextAnimeController.animeInst.AnimePlay(3); }

            if (timetrack > 4f && timetrack < 4f + Time.deltaTime)
            {
                if (SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 25;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 25;
                }
                TextAnimeController.animeInst.AnimePlay(4); }

            if (timetrack > 5f && timetrack < 5f + Time.deltaTime)
            {
                if (SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 30;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 30;
                }
                TextAnimeController.animeInst.AnimePlay(5); }

            if (timetrack > 6f && timetrack < 6f + Time.deltaTime)
            {
                if (SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 35;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 35;
                }
                TextAnimeController.animeInst.AnimePlay(6); }

            if (timetrack > 7f && timetrack < 7f + Time.deltaTime)
            {
                if (SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 40;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 40;
                }
                TextAnimeController.animeInst.AnimePlay(7); }

            if (timetrack > 8f && timetrack < 8f + Time.deltaTime)
            {
                if (SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 40;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 40;
                }
                TextAnimeController.animeInst.AnimePlay(7); }

            if (timetrack > 9f && timetrack < 9f + Time.deltaTime)
            {
                if (SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 40;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 40;
                }
                TextAnimeController.animeInst.AnimePlay(7); }

            if (timetrack > 10f && timetrack < 10f + Time.deltaTime)
            {
                if (SceneManagement.dash)
                {
                    Score.inst.score = Score.inst.score - 40;
                }
                else
                {
                    Score.inst.score = Score.inst.score + 40;
                }
                TextAnimeController.animeInst.AnimePlay(7); }

             }
        else
        {
            if (touchcountpress == 0)
            {
                pos.z = transform.position.z;
                pos.z = Mathf.SmoothStep(pos.z, pos.z + 0.15f, t);
                t = t - 0.1f;
                t = Mathf.Clamp01(t);
                transform.position = pos;
            }
        }

        if(isended)
        {
            streaktime = streaktime + Time.deltaTime;
            if (streaktime > 0.5f)
            {
                isended = false;
                timetrack = 0f;
                streaktime = 0f;
            }
        }

        if (timetrack >= 2)
        {
            streakeffect.Play();
        }
        else
        {
            streakeffect.Stop();
        }

    }

}
