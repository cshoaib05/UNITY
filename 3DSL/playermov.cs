using UnityEngine;

public class playermov : MonoBehaviour
{
    private Vector3 pos;
    public float speed;

    void Start()
    {        
        pos = transform.position; 
    }

    void Update()
    {
        if(Input.touchCount>0 && obscollider.isalive)
        {
            pos.z = pos.z + speed + Time.deltaTime * 0.2f;
            transform.position = pos;
            speed = speed + Time.deltaTime / 700;
            print(Input.touches[0].deltaTime);
        }

        if(Input.GetKey(KeyCode.Space) && obscollider.isalive)
        {
            pos.z = pos.z +speed +Time.deltaTime;
            transform.position = pos;
            speed = speed + Time.deltaTime / 700;
        }

       if(Input.GetTouch(0).deltaTime > 1f && Input.GetTouch(0).deltaTime < 1.5f)  { Score.inst.score = Score.inst.score + 10; }

        if (Input.GetTouch(0).deltaTime > 1.5f && Input.GetTouch(0).deltaTime < 2f) { Score.inst.score = Score.inst.score + 15; }

        if (Input.GetTouch(0).deltaTime > 2f && Input.GetTouch(0).deltaTime < 2.5f)  { Score.inst.score = Score.inst.score + 20; }

        if (Input.GetTouch(0).deltaTime > 2.5f && Input.GetTouch(0).deltaTime < 3f)  { Score.inst.score = Score.inst.score + 25; }

        if (Input.GetTouch(0).deltaTime > 3f && Input.GetTouch(0).deltaTime < 3.5f)  { Score.inst.score = Score.inst.score + 30; }

    }

}
