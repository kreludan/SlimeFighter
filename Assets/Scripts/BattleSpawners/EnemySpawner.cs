using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> potentialEnemiesToSpawn = new List<GameObject>();
    // Start is called before the first frame update
    public void SpawnEnemy()
    {
        System.Random random = new System.Random();
        SpawnEnemy(random.Next(0, potentialEnemiesToSpawn.Count));
    }

    public void SpawnEnemy(int i)
    {
        if (i > potentialEnemiesToSpawn.Count - 1) return;
        Debug.Log(potentialEnemiesToSpawn);
        Instantiate(potentialEnemiesToSpawn[i], transform.position, Quaternion.identity);
    }
}
