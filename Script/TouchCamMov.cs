using UnityEngine;
using UnityEngine.UI;

public class CamMov : MonoBehaviour
{
    [SerializeField] GameObject[] player;
    private float offset;
    private Vector3 pos;
    private Vector3 revivepos;
    public static float speed;
    private float zpos;
    private Vector3 touchpos, playerpos;

    public GameObject scorepanel;

    private void Start()
    {
        speed = 0.5f;
        pos = transform.position;
        playerpos = player[customizer.selectedplayer].transform.position;
        touchpos = new Vector3(0f, 0f, 0f);
        offset = transform.position.z - player[customizer.selectedplayer].transform.position.z ;

    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touchpos = Input.GetTouch(0).deltaPosition;
            playerpos.x = Mathf.Clamp(playerpos.x + (touchpos.x * Time.deltaTime * 0.2f), -4.7f, 3.07f);
        }
        if(!admobads.revivedone)
        {
            zpos = zpos + speed;
            speed = speed + (Time.deltaTime / 500);
            playerpos.z = zpos;
            player[customizer.selectedplayer].transform.position = playerpos;
        }
        else
        {
            revivepos = player[customizer.selectedplayer].transform.position + new Vector3(0, 0, 32f);
            player[customizer.selectedplayer].transform.position = revivepos;
            player[customizer.selectedplayer].SetActive(true);
            admobads.revivedone = false;
            
           
        }
        pos.z = player[customizer.selectedplayer].transform.position.z + offset;
        transform.position = pos;
    }

    public void Update()
    {
        if(ObsColl.fuelisover == true)
        {
            zpos = zpos + speed;
            speed = speed - 0.005f;
            playerpos.z = zpos;
            player[customizer.selectedplayer].transform.position = playerpos;
            pos.z = player[customizer.selectedplayer].transform.position.z + offset;
            transform.position = pos;
            print(speed);
            if (speed < 0.1)
            {
                player[customizer.selectedplayer].SetActive(false);
                scorepanel.SetActive(true);
                ObsColl.fuelisover = false;
            }
        }
    }

}
