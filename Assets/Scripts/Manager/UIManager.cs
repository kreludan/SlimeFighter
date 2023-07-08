using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private MainMenuUI mainMenuUI;
    public MainMenuUI MainMenuUI => mainMenuUI;

    [SerializeField]
    private BattleUI battleUI;
    public BattleUI BattleUI => battleUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
