using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar;
    private const int MAX_HEALTH = 3;
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
        for (int i = 0; i < MAX_HEALTH; i++)
        {
            GameObject currentChild = healthBar.transform.GetChild(i).gameObject;
            if (i < characterHealth - 1)
            {
                currentChild.SetActive(true);
            }
            else
            {
                currentChild.SetActive(false);
            }
            
        }
    }
}
