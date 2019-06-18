using UnityEngine;
using System.Collections;
using TMPro;


public class obscollider : MonoBehaviour
{

    public GameObject dashscorepanel;
    public ParticleSystem outeffect;
    public GameObject player;
    public GameObject Mainplayer;
    public GameObject scorepanel;
    private Renderer playerrender;
    public GameObject sphere;
    public TrailRenderer trailRenderer;
    public static bool isalive;
    public static int vibrate;
    public static int outcount;
    private MeshCollider mesh;
    public TextMeshProUGUI lives;
 

    private void Start()
    {
        outcount = 0;
        mesh = player.GetComponent<MeshCollider>();
        vibrate = PlayerPrefs.GetInt("vibrate",1);
        playerrender = GetComponent<Renderer>();
        isalive = true;
        if(SceneManagement.dash)
        {
            lives.enabled = true;
        }
        else
        {
            lives.enabled = false;
        }
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
            isalive = false;
            if (vibrate == 1)
            {
                Handheld.Vibrate();
            }
            StartCoroutine(waitingmethod()); 
        }

        if (other.gameObject.CompareTag("obstacles") && SceneManagement.dash)
        {
            outcount++;
            mesh.enabled = false;
            playermov.timetrack = 0f;
            sphere.SetActive(false);
            playerrender.enabled = false;
            trailRenderer.enabled = false;
            isalive = false;
            lives.text = "Lives:" + (3-outcount).ToString();
            if (vibrate == 1)
            {
                Handheld.Vibrate();
            }
            StartCoroutine(waitingmethod());
        }

    }




    IEnumerator waitingmethod()
    {
        yield return new WaitForSeconds(1.5f);


        if (SceneManagement.classic)
        {
            Adscontroller.showads();
            Time.timeScale = 0f;
            scorepanel.SetActive(true);
        }

        if (SceneManagement.timeattack || (SceneManagement.dash && outcount <3))
        {
            Mainplayer.transform.position = Mainplayer.transform.position + new Vector3(0, 0, 2f);
            playerrender.enabled = true;
            trailRenderer.enabled = true;
            isalive = true;
            StartCoroutine(waitingmethod2());
        } 
            if(SceneManagement.dash && outcount>=3)
            {
            Adscontroller.showads();
            dashscorepanel.SetActive(true);
                isalive = false;
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


