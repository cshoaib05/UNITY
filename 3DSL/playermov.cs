using UnityEngine;

public class playermov : MonoBehaviour
{
    private Vector3 pos;
    public static float speed;
    float  t = 0f;
    public float timetrack;

    void Start()
    {
        pos = transform.position;
        timetrack = 0f;
    }

    void FixedUpdate()
    {
        print(speed);
        if (Input.touchCount>0 && obscollider.isalive)
        {
            Touch touch = Input.GetTouch(0);
                pos.z = pos.z+speed;
                transform.position = pos;
            
            if(touch.phase == TouchPhase.Stationary)
            {
                timetrack += Time.deltaTime;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                timetrack = 0f;
            }

            if (timetrack > 1f && timetrack < 1f+Time.deltaTime) { Score.inst.score = Score.inst.score + 10; TextAnimeController.animeInst.AnimePlay(1); }

            if (timetrack > 2f && timetrack < 2f+ Time.deltaTime) { Score.inst.score = Score.inst.score + 15; TextAnimeController.animeInst.AnimePlay(2); }

            if (timetrack > 3f && timetrack < 3f+Time.deltaTime) { Score.inst.score = Score.inst.score + 20; TextAnimeController.animeInst.AnimePlay(3); }

            if (timetrack > 4f && timetrack < 4f + Time.deltaTime) { Score.inst.score = Score.inst.score + 25; TextAnimeController.animeInst.AnimePlay(4); }

            if (timetrack > 5f && timetrack < 5f + Time.deltaTime) { Score.inst.score = Score.inst.score + 30; TextAnimeController.animeInst.AnimePlay(5); }
        }



        if(Input.GetKey(KeyCode.Space) && obscollider.isalive)
        {
            pos.z = Mathf.Lerp(pos.z,pos.z + speed+0.1f , t);
            t += 0.02f;
            transform.position = pos; 
           print(speed);
        }
        else
        {
            t = 0;
         }


        speed = speed + Time.deltaTime / 700;
    }

}
