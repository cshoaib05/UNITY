using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Obspooling : MonoBehaviour {

    public List<GameObject> objPrefab;
    public List<GameObject> nonobjprefab;

    private Vector3 position = new Vector3(0f, 0f, 30.397f *4f);
   
    private Queue<GameObject> queue;
    private Queue<GameObject> nonqueue;

    public static Obspooling obsins;

    #region singleton
    private void Awake()
    {
        obsins = this;
    }
    #endregion

    // Use this for initialization
    void Start ()
    {
        queue = new Queue<GameObject>();
        nonqueue = new Queue<GameObject>();

        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < objPrefab.Count; i++)
            {
                GameObject temp = objPrefab[i];
                int randomIndex = Random.Range(i, objPrefab.Count);
                objPrefab[i] = objPrefab[randomIndex];
                objPrefab[randomIndex] = temp;
            }
            foreach (GameObject obs in objPrefab)
            {
                GameObject go = Instantiate(obs);
                go.SetActive(false);
                queue.Enqueue(go);
            }
        }
            

        for(int j = 0; j <80;j++)    
        {
            for (int i = 0; i < nonobjprefab.Count; i++)
            {
                GameObject temp = nonobjprefab[i];
                int randomIndex = Random.Range(i, nonobjprefab.Count);
                nonobjprefab[i] = nonobjprefab[randomIndex];
                nonobjprefab[randomIndex] = temp;
            }
            foreach (GameObject obs in nonobjprefab)
            {
                GameObject go = Instantiate(obs);
                go.SetActive(false);
                nonqueue.Enqueue(go);
            }
        }
        print(nonqueue.Count);
    }

    public void Obsgenerate()
    {
        int rand = Random.Range(0,2);
        if(rand<1)
        {
            GameObject gom = queue.Dequeue();
            gom.SetActive(true);
            gom.transform.position = position;
            position = position + new Vector3(0f, 0f, 32.397f);
            queue.Enqueue(gom);
        }
        else
        {
            GameObject go = nonqueue.Dequeue();
            go.SetActive(true);
            go.transform.position = position;
            position = position + new Vector3(0f, 0f, 32.397f);
            nonqueue.Enqueue(go);
        }
        
    }
}
