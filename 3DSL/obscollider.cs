using UnityEngine;

public class obscollider : MonoBehaviour
{
    public ParticleSystem outeffect;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.CompareTag("obstacles"))
        {
            outeffect.transform.position = player.transform.position;
            outeffect.Play();
           
            gameObject.SetActive(false);
        }
    }


}
