using UnityEngine;

public class CamMov : MonoBehaviour
{
    [SerializeField] GameObject player;
    private float offset;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        offset = transform.position.z - player.transform.position.z;
    }

    void Update()
    {
        pos.z = player.transform.position.z + offset;
        transform.position = pos;
    }
}
