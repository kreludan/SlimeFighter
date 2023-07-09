using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField]
    private int delayFrames;

    [SerializeField]
    private List<EnemySpawnerField> waves;

    private int waveNum;
    private int superWaveNum;

    private int numFramesWaited;

    private GameObject waveText;

    // Start is called before the first frame update
    void Start()
    {
        waveText = GlobalManager.Instance.UiManager.BattleUI.Wave;
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
                    waveText.SetActive(false);
                    numFramesWaited = 0;
                    waveNum++;
                    waves[waveNum - 1].SpawnWave();
                }
                else
                {
                    waveText.SetActive(true);
                    waveText.GetComponent<TMP_Text>().text = "WAVE " + (waveNum + 1);
                }
            }
        }

        
    }
}
