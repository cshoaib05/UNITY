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
            sphere.SetActive(false);
            playerrender.enabled = false;
            trailRenderer.enabled = false;
            obscollider.isalive = false;
            StartCoroutine(waitingmethod());
           
        }


    }




    IEnumerator waitingmethod()
    {
        yield return new WaitForSeconds(1);

        if(SceneManagement.timeattack)
        {
            Mainplayer.transform.position = Mainplayer.transform.position + new Vector3(0, 0, 3f);
            mesh.enabled = true;
            playerrender.enabled = true;
            trailRenderer.enabled = true;
            sphere.SetActive(true);
            obscollider.isalive = true;
        }
        else
        {
            Time.timeScale = 0f;
            scorepanel.SetActive(true);
        }
        

    }

}


