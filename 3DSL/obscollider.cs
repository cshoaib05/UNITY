using UnityEngine;
using System.Collections;

public class obscollider : MonoBehaviour
{
    public ParticleSystem outeffect;
    public GameObject player;
    public GameObject Mainplayer;
    public GameObject scorepanel;
    private Renderer playerrender;
    public GameObject sphere;
    public TrailRenderer trailRenderer;
    public static bool isalive;

    public static int vibrate;

    private MeshCollider mesh;
    private void Start()
    {
        mesh = player.GetComponent<MeshCollider>();
        vibrate = PlayerPrefs.GetInt("vibrate");
        playerrender = GetComponent<Renderer>();
        isalive = true;
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.CompareTag("obstacles") && SceneManagement.classic )
        {
            outeffect.transform.position = player.transform.position;
            outeffect.Play();
            playerrender.enabled = false;
            trailRenderer.enabled = false;
            sphere.SetActive(false);
            isalive = false;
            if(vibrate ==1)
            {
                Handheld.Vibrate();
            }
            StartCoroutine(waitingmethod());
        }


        if (other.gameObject.CompareTag("obstacles") && SceneManagement.timeattack)
        {
            mesh.enabled = false;
            playermov.timetrack = 0f;
            sphere.SetActive(false);
            playerrender.enabled = false;
            trailRenderer.enabled = false;
            obscollider.isalive = false;
            if (vibrate == 1)
            {
                Handheld.Vibrate();
            }
            StartCoroutine(waitingmethod());
            
        }
    }




    IEnumerator waitingmethod()
    {
        yield return new WaitForSeconds(1);

        if(SceneManagement.timeattack)
        {
            Mainplayer.transform.position = Mainplayer.transform.position + new Vector3(0, 0,1f);
            playerrender.enabled = true;
            trailRenderer.enabled = true;
            obscollider.isalive = true;
            StartCoroutine(waitingmethod2());
        }
        else
        {
            Time.timeScale = 0f;
            scorepanel.SetActive(true);
        }
    }


    IEnumerator waitingmethod2()
    {
        yield return new WaitForSeconds(0.3f);
        playerrender.enabled = false;
        trailRenderer.enabled = false;
        StartCoroutine(waitingmethod3());
    }


    IEnumerator waitingmethod3()
    {
     yield return new WaitForSeconds(0.3f);
        playerrender.enabled = true;
        trailRenderer.enabled = true;
        StartCoroutine(waitingmethod4());
    }

    IEnumerator waitingmethod4()
    {
        yield return new WaitForSeconds(0.3f);
        playerrender.enabled = false;
        trailRenderer.enabled = false;
        StartCoroutine(waitingmethod5());
    }

    IEnumerator waitingmethod5()
    {
        yield return new WaitForSeconds(0.3f);
        playerrender.enabled = true;
        trailRenderer.enabled = true;
        mesh.enabled = true;
        sphere.SetActive(true);
    }
}


