using UnityEngine.UI;
using UnityEngine;

public class musicvolume : MonoBehaviour
{
    public Slider Slider;
 	AudioSource source;
    public GameObject audiomanager;
    public Toggle toggle;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("musicvol");
        Slider.value = PlayerPrefs.GetFloat("musicvol");
    }


    public void music()
    {
        source.volume = Slider.value;
        PlayerPrefs.SetFloat("musicvol",source.volume);
    }

    public void sfx()
    {
       AudioSource[] source = audiomanager.GetComponents<AudioSource>();

        foreach (AudioSource s in source)
        {
            if(s.name !="crash")
            {
                if(toggle.isOn)
                {
                    s.volume = 1;
                }
                else
                {
                    s.volume = 0;
                }
            }
        }
    }
    
}
