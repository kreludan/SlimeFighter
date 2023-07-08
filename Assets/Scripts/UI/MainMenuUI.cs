using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour, ISelectHandler
{
    [SerializeField]
    private Button startButton;

    private GameObject lastSelection;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(eventData.selectedObject);
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
