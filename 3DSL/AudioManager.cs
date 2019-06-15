using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static int music;

    void Start()
    {
        music = PlayerPrefs.GetInt("music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
