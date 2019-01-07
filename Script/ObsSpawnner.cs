using UnityEngine;

public class creater : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pooling.inst.spawn();

        }
    }



}
