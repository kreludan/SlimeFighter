using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerField : MonoBehaviour
{
    [SerializeField]
    List<GameObject> spawners;
    [SerializeField]
    int waveNum;

    // Start is called before the first frame update
    public void SpawnWave()
    {
        foreach(GameObject spawner in spawners)
        {
            spawner.GetComponent<EnemySpawner>().SpawnEnemy(waveNum);
        }

    }
}
