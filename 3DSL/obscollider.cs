using UnityEngine;
using System.Collections;

public class obscollider : MonoBehaviour
{
    public ParticleSystem outeffect;
    public GameObject player;
    public GameObject scorepanel;
    private Renderer playerrender;
    public GameObject sphere;
    public TrailRenderer trailRenderer;
    public static bool isalive;

    private void Start()
    {
        playerrender = GetComponent<Renderer>();
        isalive = true;
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.CompareTag("obstacles"))
        {

            outeffect.transform.position = player.transform.position;
            outeffect.Play();
            playerrender.enabled = false;
            trailRenderer.enabled = false;
            sphere.SetActive(false);
            isalive = false;
            StartCoroutine(waitingmethod());
        }
    }

    
    IEnumerator waitingmethod()
    {
        yield return new WaitForSeconds(1);
        scorepanel.SetActive(true);
        Time.timeScale = 0;
    }

}


