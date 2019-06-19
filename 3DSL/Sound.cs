using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip Clip;
    [HideInInspector]public AudioSource source;
}
