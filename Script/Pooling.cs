using System.Collections.Generic;
using UnityEngine;

public class pooling : MonoBehaviour {

    public static pooling inst;

    private Vector3 position = new Vector3(0f, 0f, 30.397f);
    public int count = 0;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public Dictionary<string, Queue<GameObject>> poolDict;

    public List<Pool> pools;

     #region singleton
        private void Awake()
        {
            inst = this;
        }
        #endregion

    void Start () {

        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objpool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject go = Instantiate(pool.prefab);
                go.SetActive(false);
                objpool.Enqueue(go);
            }
            poolDict.Add(pool.tag, objpool);
        }
        
        startspawn();
	}

    void startspawn()
    {
        spawn();
        spawn();
        spawn();
    }

    public void spawn()
    {

        if (count <= 30) { SpawnRoad1(); }
        if (count > 30 && count <= 55) { SpawnRoad2(); }
        if (count > 55 && count <= 65) { SpawnRoad3(); }
        if (count > 65 && count < 75) { SpawnRoad4(); }
    }

    void SpawnRoad1()
    {
        if (count <= 29)
        {

            GameObject go = poolDict[pools[0].tag].Dequeue();
            go.SetActive(true);
            go.transform.position = position;
            position = position + new Vector3(0f, 0f, 32.397f);
            count++;

            poolDict[pools[0].tag].Enqueue(go);
            
        }
        if (count == 30)
        {
            GameObject go = poolDict[pools[1].tag].Dequeue();
            go.SetActive(true);
            go.transform.position = position;
            count++;
            position = position + new Vector3(0f, 0f, 51.608f);
            poolDict[pools[1].tag].Enqueue(go);
        }
    }

    private void SpawnRoad2()
    {
        GameObject go = poolDict[pools[2].tag].Dequeue();
        go.SetActive(true);
        go.transform.position = position;
        position = position + new Vector3(0f, 0f, 32.397f);
        count++;

        poolDict[pools[2].tag].Enqueue(go);
    }


    private void SpawnRoad3()
    {
        if (count == 56)
        {

            GameObject go = poolDict[pools[3].tag].Dequeue();
            go.SetActive(true);
            go.transform.position = position;
            poolDict[pools[3].tag].Enqueue(go);
            position = position + new Vector3(0f, 0f, 84.032f);
            count++;
        }
        if (count > 56)
        {

            GameObject go = poolDict[pools[4].tag].Dequeue();
            go.SetActive(true);
            go.transform.position = position;

            position = position + new Vector3(0f, 0f, 64.794f);
            count++;

            poolDict[pools[4].tag].Enqueue(go); 
        }
    }

    private void SpawnRoad4()
    {
        GameObject go = poolDict[pools[5].tag].Dequeue();
        go.SetActive(true);
        go.transform.position = position;
        position = position + new Vector3(0f, 0f, 79.132f);
        poolDict[pools[5].tag].Enqueue(go);
        count++;

        if (count >=75)
        {
            count = 0;
        }
    }

}
