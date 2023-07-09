using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveHandler : MonoBehaviour
{
    [SerializeField]
    private int delayFrames;

    [SerializeField]
    private List<EnemySpawnerField> waves;

    private int waveNum;
    private int superWaveNum;

    private int numFramesWaited;

    private BattleUI battleUI;
    private GameOverUI gameOverUI;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        battleUI = GlobalManager.Instance.UiManager.BattleUI;
        gameOverUI = GlobalManager.Instance.UiManager.GameOverUI;
        waveNum = 0;
        numFramesWaited = 0;
        isGameOver = true;
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
                if (isGameOver) 
                { 
                    GlobalManager.Instance.UiManager.ActivateGameOverUI(false);
                    Debug.Log("YOU WIN");
                    isGameOver = false;
                }
            }
            else
            {
                isGameOver = true;
                if (!GlobalManager.Instance.UiManager.ControlsUI.gameObject.activeSelf)
                {
                    numFramesWaited++;
                    if (numFramesWaited == delayFrames)
                    {
                        battleUI.Wave.SetActive(false);
                        battleUI.ExtraLife.SetActive(false);
                        numFramesWaited = 0;
                        waveNum++;
                        waves[waveNum - 1].SpawnWave();
                    }
                    else
                    {
                        Projectile[] projectiles = FindObjectsOfType<Projectile>();
                        foreach(Projectile p in projectiles)
                        {
                            Destroy(p.gameObject);
                        }

                        battleUI.Wave.SetActive(true);
                        battleUI.UpdateWaveNumber(waveNum + 1);
                       // Debug.Log("WAVE " + (waveNum + 1));

                        if((waveNum + 1) % 5 == 0)
                        {
                            battleUI.ExtraLife.SetActive(true);
                            GameObject player = GameObject.Find("Player");
                            if(player.GetComponent<Character>().health < 5)
                            {
                                player.GetComponent<Character>().health += 1;
                                GlobalManager.Instance.UiManager.BattleUI.HealthUpdate(player.GetComponent<Character>().health);
                                // Debug.Log("EXTRA LIFE");
                            }
                        }
                    }
                }
            }
        }

        
    }
}
