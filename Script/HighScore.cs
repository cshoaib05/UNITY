using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text;
    public TextMeshProUGUI finaltext;
    
    int score;

    void Start()
    { 
       text =  GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    void FixedUpdate()
    {
        text.text = score++.ToString();
        if (score > PlayerPrefs.GetInt("highscore",0))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        finaltext.text = score.ToString();
    }
}