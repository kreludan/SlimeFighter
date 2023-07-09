using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyToSpawn;


    public void SpawnEnemy(int waveNum)
    {
        GameObject newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().waveNum = waveNum;
        Debug.Log(newEnemy.GetComponent<Enemy>().waveNum);
    }
}
