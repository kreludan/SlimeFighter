using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerField : MonoBehaviour
{
    [SerializeField]
    int spawnEveryXFrames;
    [SerializeField]
    List<GameObject> spawners;
    private int frameNum;


    // Start is called before the first frame update
    void Start()
    {
        frameNum = 0;

    }

    // Update is called once per frame
    void Update()
    {
        frameNum += 1;
        if(frameNum % spawnEveryXFrames == 0)
        {
            System.Random random = new System.Random();
            spawners[random.Next(0, spawners.Count)].GetComponent<EnemySpawner>().SpawnEnemy();

        }
    }
}
