using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsController : MonoBehaviour
{

    Vector3 objposition;
    int rankey;
    public GameObject player;
    public  List<GameObject> objPrefab;
    private int key = 0;

    public Dictionary<int, Queue<GameObject>> objDict;


    void Start()
    {
        objposition = new Vector3(0f, 0f, 10f);

        objDict = new Dictionary<int, Queue<GameObject>>();

        foreach(GameObject obj in objPrefab)
        {
            key++;
            Queue<GameObject> objpool = new Queue<GameObject>();

            for(int i =0; i<10; i++)
            {
                GameObject go = Instantiate(obj,obj.transform.position,obj.transform.rotation);
                go.SetActive(false);
                objpool.Enqueue(go);
            }
            objDict.Add(key, objpool);
        }
    }

    public void SpawnObs()
    {
        Vector3 temppos;
        if(Score.inst.score <100  ) { rankey = Random.Range(1, 10); }
        if(Score.inst.score <300 && Score.inst.score >100) { rankey = Random.Range(1, 14); }
        if(Score.inst.score >300 || SceneManagement.dash) { rankey = Random.Range(1, objPrefab.Count + 1); }

        GameObject go = objDict[rankey].Dequeue();
        go.SetActive(true);
        temppos = go.transform.position;
        temppos.z = objposition.z;
        go.transform.position = temppos;
        objposition = objposition + new Vector3(0f, 0f, 10f);
        objDict[rankey].Enqueue(go);
    }
}
