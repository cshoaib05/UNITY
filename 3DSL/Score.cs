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
        if (Input.GetKey(KeyCode.Space ) && Time.frameCount%7 == 0 && obscollider.isalive)
        {
            scoretext.text = score++.ToString();
            scorepaneltext.text = score.ToString();

        }

    }
}
