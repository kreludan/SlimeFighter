using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private MainMenuUI mainMenuUI;
    [SerializeField]
    private BattleUI battleUI;
    [SerializeField]
    private PauseUI pauseUI;
    [SerializeField]
    private GameOverUI gameOverUI;

    public MainMenuUI MainMenuUI => mainMenuUI;
    public BattleUI BattleUI => battleUI;
    public PauseUI PauseUI => pauseUI;
    public GameOverUI GameOverUI => gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateGameOverUI()
    {
        gameOverUI.gameObject.SetActive(true);
    }
}
