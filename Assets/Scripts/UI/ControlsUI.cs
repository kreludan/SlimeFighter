using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlsUI : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    private GameObject lastSelection;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
        Time.timeScale = 0;
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

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
