using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    [SerializeField] GameObject[] ObsPrefabs;
    private Vector3 position = new Vector3(0f, 0f, 30.397f * 4f);

    private List<GameObject> delete;

    private void Start()
    {
        delete = new List<GameObject>();
    }

    public void Obsgenerate()
    {
        GameObject go = Instantiate(ObsPrefabs[Random.Range(0,6)], position, transform.rotation, this.transform) as GameObject;
        position = position + new Vector3(0f, 0f, 32.397f);
        delete.Add(go);
    }


    public void DeleteObs()
    {
        Destroy(delete[0]);
        delete.RemoveAt(0);
    }

}

