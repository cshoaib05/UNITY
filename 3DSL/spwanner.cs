using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanner : MonoBehaviour
{
    public ObsController obsController;

    private void Start()
    {
        obsController.SpawnObs();
        obsController.SpawnObs();
        obsController.SpawnObs();
        obsController.SpawnObs();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("ads");

        if(other.gameObject.CompareTag("obstacles"))
        {
            obsController.SpawnObs();
        }
    }
}
