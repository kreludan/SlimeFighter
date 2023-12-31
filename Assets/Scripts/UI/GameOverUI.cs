using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Image winLose;
    [SerializeField]
    private Sprite winImg;
    [SerializeField]
    private Sprite loseImg;

    public Image WinLose => winLose;
    public Sprite WinImg => winImg;
    public Sprite LoseImg => loseImg;

    
    private GameObject lastSelection;
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        DisableMouseInput();
    }

    private void DisableMouseInput()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelection);
        }
        else
        {
            lastSelection = EventSystem.current.currentSelectedGameObject;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) EventSystem.current.SetSelectedGameObject(lastSelection);
    }
}
