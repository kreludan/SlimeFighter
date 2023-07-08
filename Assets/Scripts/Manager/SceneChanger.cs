using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GlobalManager.Instance.UiManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        uiManager.MainMenuUI.gameObject.SetActive(false);
        uiManager.BattleUI.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}