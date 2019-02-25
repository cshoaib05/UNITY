using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class healthController : MonoBehaviour
{
    public Slider playerslider;
    public GameObject Gameover;
    public TextMeshProUGUI meet;
    public TextMeshProUGUI score;
    public int count;
    public static bool won;
    public TextMeshProUGUI timer;
    private float startTime;
    private float timeing;

    private void Awake()
    {
      
        count = 0;
        won = false;
    }

    private void Start()
    {
        startTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("fire"))
        {
            playerslider.value -= 0.6f;
        }
        if(collision.CompareTag("heart"))
        {
            playerslider.value = 1f;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("rock"))
        {
            playerslider.value -= 0.6f;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           playerslider.value=1;
            won = true;
            count++;
            meet.text = count.ToString();
        }
    }



    private void FixedUpdate()
    {
        float t = Time.time - startTime;
        float m = t % 3600;
        string minutes = ((int)m / 60).ToString("00");
        string seconds = (m % 60).ToString("00");

        timeing += Time.deltaTime;
        timer.text =  minutes + ":" + seconds;

        if (playerslider.value <=0)
        {
            Gameover.SetActive(true);
            score.text = count.ToString();

            if(PlayerPrefs.GetInt("highest") < count)
            {
                PlayerPrefs.SetInt("highest", count);
            }
            int ghigh = PlayerPrefs.GetInt("highest");

            if (ghigh < count)
            {
                PlayerPrefs.SetString("time", timer.text);
            }
          
         
        }
    }
}
