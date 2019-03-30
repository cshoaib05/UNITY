using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsController : MonoBehaviour
{

    Vector3 objposition;

    public GameObject player;
    public  List<GameObject> objPrefab;
    private int key = 0;
    public Dictionary<int, Queue<GameObject>> objDict;


    void Start()
    {
        objposition = new Vector3(0f, 0f, 5f);

        objDict = new Dictionary<int, Queue<GameObject>>();
        foreach(GameObject obj in objPrefab)
        {
            key++;
            Queue<GameObject> objpool = new Queue<GameObject>();

            for(int i =0; i<100; i++)
            {
                GameObject go = Instantiate(obj);
                go.SetActive(false);
                objpool.Enqueue(go);
            }
            objDict.Add(key, objpool);
        }
    }

    public void SpawnObs()
    {
            int rankey = Random.Range(1, 8);
            GameObject go = objDict[rankey].Dequeue();
            go.SetActive(true);
            go.transform.position = go.transform.position + objposition;
            objposition = objposition + objposition;
            objDict[rankey].Enqueue(go);         
    }


}
