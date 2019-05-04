using UnityEngine;

public class playermov : MonoBehaviour
{
    private Vector3 pos;
    public static float speed;
    float  t = 0f;

    void Start()
    {
        speed = 8f;
        pos = transform.position; 
    }

    void Update()
    {


        if (Input.touchCount>0 && obscollider.isalive)
        {
            Touch touch = Input.GetTouch(0);

            pos.z = Mathf.Lerp(0f,pos.z + speed + Time.deltaTime * 0.2f,t);
            t += 0.05f;
            transform.position = pos;
            speed = speed + Time.deltaTime / 700;

            if (touch.deltaTime > 1f && touch.deltaTime < 1.5f) { Score.inst.score = Score.inst.score + 10; TextAnimeController.animeInst.AnimePlay(1); }

            if (touch.deltaTime > 1.5f && touch.deltaTime < 2f) { Score.inst.score = Score.inst.score + 15; TextAnimeController.animeInst.AnimePlay(2); }

            if (touch.deltaTime > 2f && touch.deltaTime < 2.5f) { Score.inst.score = Score.inst.score + 20; TextAnimeController.animeInst.AnimePlay(3); }

            if (touch.deltaTime > 2.5f && touch.deltaTime < 3f) { Score.inst.score = Score.inst.score + 25; TextAnimeController.animeInst.AnimePlay(4); }

            if (touch.deltaTime > 3f && touch.deltaTime < 3.5f) { Score.inst.score = Score.inst.score + 30; TextAnimeController.animeInst.AnimePlay(5); }
        }



        if(Input.GetKey(KeyCode.Space) && obscollider.isalive)
        {
            pos.z = Mathf.Lerp(pos.z,pos.z + speed * Time.deltaTime, t);
            t += 0.02f;
            transform.position = pos; 
           print(speed);
        }

        speed = speed + Time.deltaTime / 700;


    }

}
