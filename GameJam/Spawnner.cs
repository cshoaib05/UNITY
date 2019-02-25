using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    [SerializeField] GameObject[] SpawwnerF;
    [SerializeField] GameObject[] SpawwnerM;
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject[] objects;
    [SerializeField] GameObject[] Obsspawnnerpos;

    private Queue<GameObject> queue;


    void Start()
    {
        queue = new Queue<GameObject>();


        players[1].transform.position = SpawwnerF[Random.Range(0,4)].transform.position;
        players[0].transform.position = SpawwnerM[Random.Range(0,4)].transform.position;


        for(int i=0; i<Obsspawnnerpos.Length; i++)
        {
            GameObject temp = Obsspawnnerpos[i];
            int rand = Random.Range(0,Obsspawnnerpos.Length);
            Obsspawnnerpos[i] = Obsspawnnerpos[rand];
            Obsspawnnerpos[rand] = temp;
        }

        for(int i=0; i<30; i++)
        {
            if(i<13)
            {
             GameObject go = Instantiate(objects[0]);
             go.SetActive(false);
             queue.Enqueue(go);
            }

            if (i>=13 &&  i<23)
            {
             GameObject go1 = Instantiate(objects[1]);
             go1.SetActive(false);
             queue.Enqueue(go1);
            }

            if (i>=23 && i<28)
            {
             GameObject go2 = Instantiate(objects[2]);
             go2.SetActive(false);
             queue.Enqueue(go2);
            }
        }


        for(int p = 0; p<Obsspawnnerpos.Length; p++)
        {
            GameObject go = queue.Dequeue();
            go.SetActive(true);
            go.transform.position = Obsspawnnerpos[p].transform.position;
            queue.Enqueue(go);
        }

    }

    private void FixedUpdate()
    {
        if(healthController.won==true)
        {
            players[1].transform.position = SpawwnerF[Random.Range(0, 4)].transform.position;
            players[0].transform.position = SpawwnerM[Random.Range(0, 4)].transform.position;
            healthController.won = false;
        }
    }


}
