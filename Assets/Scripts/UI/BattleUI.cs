using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    private GameObject points;
    [SerializeField]
    private GameObject wave;
    [SerializeField]
    private GameObject extraLife;
    [SerializeField]
    private Image numberWave1;
    [SerializeField]
    private Image numberWave2;
    [SerializeField]
    private List<Sprite> listNumberWave;
    public GameObject HealthBar => healthBar;
    public GameObject Points => points;
    public GameObject Wave => wave;
    public GameObject ExtraLife => extraLife;

    private const int MAX_HEALTH = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthUpdate(int characterHealth)
    {
        Debug.Log("Health Character : " + characterHealth);
        for (int i = 0; i < MAX_HEALTH; i++)
        {
            GameObject currentChild = healthBar.transform.GetChild(i).gameObject;
            currentChild.SetActive(false);
        }
        GameObject player = GameObject.Find("Player");
        for (int i = 0; i < player.GetComponent<Character>().health; i++)
        {
            GameObject currentChild = healthBar.transform.GetChild(i).gameObject;
            currentChild.SetActive(true);
        }
    }

    public void UpdateWaveNumber(int waveNumber)
    {
        int firstNumber = waveNumber / 10;
        int secondNumber = waveNumber % 10;

        numberWave1.sprite = listNumberWave[firstNumber];
        numberWave2.sprite = listNumberWave[secondNumber];
    }

    public void ExtraLifePopup() 
    {
        
    }
}
