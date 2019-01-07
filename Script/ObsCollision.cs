using UnityEngine;
using UnityEngine.UI;

public class ObsColl : MonoBehaviour
{
    [SerializeField] GameObject distruct;
    [SerializeField] GameObject revive;
    [SerializeField] GameObject garb;
    [SerializeField] GameObject scorepanel;
    public Slider fuelbar;
    public static bool fuelisover;
    int tltgmpld,adsshow;
    private AudioSource aduio;

    private void Start()
    {
        aduio = GetComponent<AudioSource>();
        fuelisover = false;
        adsshow = 0;
        fuelbar.value = 1;
        tltgmpld = PlayerPrefs.GetInt("played");   
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("BrkObs"))
        {
            other.gameObject.SetActive(false);
            Instantiate(distruct, transform.position, transform.rotation);
            Time.timeScale = 0f;
            gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("crash");

            
            if(Application.internetReachability != NetworkReachability.NotReachable && adsshow < 3)
            {
                revive.SetActive(true);
                adsshow++;
            }
            else
            {
                scorepanel.SetActive(true);
            }
            tltgmpld++;
            PlayerPrefs.SetInt("played", tltgmpld);
            
        }

        if (other.gameObject.CompareTag("fuel"))
        {
            other.gameObject.SetActive(false);
            fuelbar.value = 1f;
        }

        if (other.gameObject.CompareTag("garb"))
        {
            other.gameObject.SetActive(false);
            garb.SetActive(true);
            garb.transform.position = other.transform.position;
            FindObjectOfType<AudioManager>().Play("obs");

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cone"))
        {
            FindObjectOfType<AudioManager>().Play("obs");

        }
    }

    private void FixedUpdate()
    {
        fuelbar.value = fuelbar.value - (Time.deltaTime /50);
        if(fuelbar.value==0)
        {
            fuelisover = true;
           aduio.volume = 0.1f;
            Time.timeScale = 0f;
           
        }
    }

}
