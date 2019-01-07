using UnityEngine;

public class ObsCreate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Obspooling.obsins.Obsgenerate();
        }
    }
}
