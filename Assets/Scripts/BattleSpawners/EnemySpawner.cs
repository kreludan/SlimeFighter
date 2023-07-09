using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyToSpawn;

    [SerializeField]
    public int delay = 0;

    private bool timerTicking;
    private int framesWaited;
    private int storedWaveNum;

    private void Start()
    {
        timerTicking = false;
    }


    private void Update()
    {
        if(timerTicking)
        {
            framesWaited++;
            if(framesWaited >= delay)
            {
                GameObject newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().waveNum = storedWaveNum;
                Debug.Log(newEnemy.GetComponent<Enemy>().waveNum);
                timerTicking = false;
            }
        }
    }


    public void SpawnEnemy(int waveNum)
    {
        if(delay == 0)
        {
            GameObject newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().waveNum = waveNum;
            Debug.Log(newEnemy.GetComponent<Enemy>().waveNum);
        }
        else
        {
            timerTicking = true;
            framesWaited = 0;
            storedWaveNum = waveNum;
        }
    }
}
