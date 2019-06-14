using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score inst;
    
    public TextMeshProUGUI scoretext;

    public TextMeshProUGUI scorepaneltext;
    public int score;


    public void Awake()
    {
        inst = this;
    }

    void Start()
    {

        score = 0;

    }

    void FixedUpdate()
    {

        if ((Input.touchCount > 0) && Time.frameCount%15 == 0 && obscollider.isalive)
        {
            score++;
        }

        scoretext.text = score.ToString();
        scorepaneltext.text = score.ToString();
        
        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
