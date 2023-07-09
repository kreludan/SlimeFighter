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
    private PauseMenuUI pauseMenuUI;
    [SerializeField]
    private GameOverUI gameOverUI;

    public MainMenuUI MainMenuUI => mainMenuUI;
    public BattleUI BattleUI => battleUI;
    public PauseMenuUI PauseMenuUI => pauseMenuUI;
    public GameOverUI GameOverUI => gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && ( !MainMenuUI.gameObject.activeSelf && !GameOverUI.gameObject.activeSelf && !BattleUI.Wave.activeSelf))
        {
            if (!PauseMenuUI.gameObject.activeSelf)
            {
                PauseMenuUI.gameObject.SetActive(true);
            }
            else
            {
                PauseMenuUI.gameObject.SetActive(false);
            }
        }
    }

    public void ActivateGameOverUI(bool isDead)
    {
        pauseMenuUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        gameOverUI.WinLose.sprite = isDead ? GameOverUI.LoseImg : GameOverUI.WinImg;
    }
}
