using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{

    public GameObject minionPrefab;
    public Transform minionSpawnLocation;
    int minionCounter = 0;

    float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time % 60;

        if (timer <= 5 && minionCounter < 5)
        {
            GameObject minion = Instantiate(minionPrefab, minionSpawnLocation);
            minion.transform.parent = transform.parent;
            timer = 0;
            minionCounter += 1; ;
        }

        if (timer >= 30 && minionCounter == 5)
        {
            minionCounter = 0;
            timer = 0;
        }
    }

 
}
