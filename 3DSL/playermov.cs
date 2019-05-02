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
        if(Input.GetKey(KeyCode.Space) && obscollider.isalive)
        {
            pos.z = pos.z +speed +Time.deltaTime;
            transform.position = pos;
            speed = speed + Time.deltaTime / 700;
        }
    }

}
