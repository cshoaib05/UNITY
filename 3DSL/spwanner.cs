using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanner : MonoBehaviour
{
    public ObsController obsController;

    private void Start()
    {
        for (int i= 0;i<10;i++)
        {
            obsController.SpawnObs();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("obstacles"))
        {
            obsController.SpawnObs();
        }
    }
}
