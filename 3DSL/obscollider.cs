using UnityEngine;

public class obscollider : MonoBehaviour
{
    public ParticleSystem outeffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("obstacles"))
        {
            outeffect.Play();
            gameObject.SetActive(false);
        }
    }


}
