using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionSpawner : MonoBehaviour
{

    public GameObject minionPrefab;
    public Transform minionSpawnLocation;
    public float spawnTime = 30;
    public int minionPerWave = 5;
    public float spawnTimer;

    int minionCounter = 0;

    private void Start()
    {
        spawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn Timer wird runter gezählt.
        spawnTimer -= Time.deltaTime;


        //Es werden solange Minions pro Sekunde gespawnt, bis genauso viele Minions gespawnt sind, wie pro Wave erlaubt sind. 
        if (spawnTimer <= 0.0f && minionCounter < minionPerWave)
        {
            GameObject minion = Instantiate(minionPrefab, new Vector3(minionSpawnLocation.position.x, minionSpawnLocation.position.y, minionSpawnLocation.position.z), Quaternion.identity);
            minion.transform.parent = transform;
            spawnTimer = 0.75f;
            minionCounter += 1; ;
        }

        //Sobald genug Minions gespawnt sind, wird der Timer wieder zurückgesetzt und nach der angegebenen Zeit, wird erneut gespawnt.
        if (spawnTimer <= 0.0f && minionCounter == minionPerWave)
        {
            minionCounter = 0;
            spawnTimer = spawnTime;
        }
    }

   

 
}
