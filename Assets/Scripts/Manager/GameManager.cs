using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 playerSpawner;
    [SerializeField]
    private GameObject enemy;

    public GameObject Player => player;
    public Vector3 PlayerSpawner => playerSpawner;
    public GameObject Enemy => enemy;

    private GameObject playerInstance;

    private List<GameObject> healthBarChildren;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRun()
    {
        //reset healthbar
        foreach (Transform child in GlobalManager.Instance.UiManager.BattleUI.HealthBar.transform)
        {
            child.gameObject.SetActive(true);
        }

        GlobalManager.Instance.UiManager.PauseMenuUI.gameObject.SetActive(false);
        GlobalManager.Instance.UiManager.GameOverUI.gameObject.SetActive(false);
        GlobalManager.Instance.UiManager.BattleUI.gameObject.SetActive(false);
        GlobalManager.Instance.UiManager.ControlsUI.gameObject.SetActive(true);
    }
}
