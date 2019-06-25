using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    public static int music;
    public Sound[] sound;


    private void Awake()
    {
        music = PlayerPrefs.GetInt("music",1);

        foreach (Sound s in sound)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            if(music==1)
            {
                s.source.volume = 1;
            }
            else
            {
                s.source.volume = 0;
            }
            
        }
    }


    public void Play(string name)
    {
        foreach (Sound s in sound)
        {
            if (music == 1)
            {
                s.source.volume = 1;
            }
            else
            {
                s.source.volume = 0;
            }
            if (s.name == name)
            {
                s.source.Play();
            }
        }
    }

}
