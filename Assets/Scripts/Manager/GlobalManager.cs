using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    [SerializeField]
    private SceneChanger sceneChanger;
    public SceneChanger SceneChanger => sceneChanger;
    [SerializeField]
    private UIManager uiManager;
    public UIManager UiManager => uiManager;

    public static GlobalManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
