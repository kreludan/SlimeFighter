using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField]
    private int delayFrames;

    [SerializeField]
    private List<EnemySpawnerField> waves;

    private int waveNum;

    private int numFramesWaited;



    // Start is called before the first frame update
    void Start()
    {
        waveNum = 0;
        numFramesWaited = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy[] allEnemies = FindObjectsOfType<Enemy>();
        int numEnemiesInWave = 0;
        for(int i = 0; i < allEnemies.Length; i++)
        {
            if (allEnemies[i].waveNum == waveNum) numEnemiesInWave++;
        }

        if(numEnemiesInWave == 0)
        {
            if(waveNum == waves.Count)
            {
                Debug.Log("YOU WIN");
            }
            else
            {
                numFramesWaited++;
                if (numFramesWaited == delayFrames)
                {
                    numFramesWaited = 0;
                    waveNum++;
                    waves[waveNum - 1].SpawnWave();
                }
                else
                {
                    Debug.Log("WAVE " + (waveNum + 1));
                }
            }
        }

        
    }
}
