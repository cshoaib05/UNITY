using TMPro;
using UnityEngine;

public class scoresdata : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI timeplayed;
    public TextMeshProUGUI vehicleunlckd;
    public TextMeshProUGUI lngstrn;
    int run;
    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("highscore").ToString();
        timeplayed.text = PlayerPrefs.GetInt("played").ToString();
        vehicleunlckd.text = PlayerPrefs.GetInt("unlock").ToString();
        run = PlayerPrefs.GetInt("highscore");
        run = run / 1000;
        lngstrn.text = run.ToString() + " KM";
    }


}
