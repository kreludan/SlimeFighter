using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    [SerializeField]
    private SceneChanger sceneChanger;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private GameManager gameManager;
    public SceneChanger SceneChanger => sceneChanger;
    public UIManager UiManager => uiManager;
    public GameManager GameManager => gameManager;

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
