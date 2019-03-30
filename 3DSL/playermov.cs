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
        if(Input.GetKey(KeyCode.Space))
        {
            pos.z = pos.z +speed+Time.deltaTime;
            transform.position = pos;
        }
    }



}
