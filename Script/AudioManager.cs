using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{    
     public Sound[] Sounds;
    public static int sfxvolume;


    public void Awake()
    {
        sfxvolume = 1;
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            if(s.source.name =="crash")
            {
                s.source.volume = s.volume;
            }
            else
            {
                s.source.volume = sfxvolume;
            }
             s.source.clip = s.clip ;
            s.source.pitch = s.pitch;
        }
    }

 public void Play( string name)
    {
        foreach (Sound s in Sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
        }
    }


}
