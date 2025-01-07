using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.HID;
//using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }
    
    private readonly string START_SCENE = "Start";
    private readonly string MAIN_SCENE = "Main";
    private readonly string GAME_OVER_SCENE = "GameOver";
    private readonly string WIN_SCENE = "Win";
    private readonly string CONTROLS_SCENE = "Controls";
    private readonly string POINT_SYSTEM_SCENE = "PointSystem";

    public Button playButton;
    public Button controlsButton;
    public Button pointsButton;
    public Button backButton;

    public void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != START_SCENE)
        {
            SceneManager.LoadScene(START_SCENE, LoadSceneMode.Single);
        }
    }
    
    private void Start()
    {
        FindPlayButton();
        FindControlsButton();
        FindPointSystemButton();
        FindBackButton();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == CONTROLS_SCENE || scene.name == POINT_SYSTEM_SCENE)
        {
            FindBackButton();
        }
        GameManager.CheckNumbersOfEnemies();
    }

    private void FindPlayButton()
    {
        playButton = GameObject.Find("Play").GetComponent<Button>();
        if (playButton)
        {
            playButton.onClick.AddListener(LoadMainScene);
        }
    }
    
    private void FindControlsButton()
    {
        controlsButton = GameObject.Find("Controls").GetComponent<Button>();
        if (controlsButton)
        {
            controlsButton.onClick.AddListener(LoadControlsScene);
        }
    }
    
    private void FindPointSystemButton()
    {
        pointsButton = GameObject.Find("PointSystem").GetComponent<Button>();
        if (pointsButton)
        {
            pointsButton.onClick.AddListener(LoadPointSystemScene);
        }
    }
    
    private void FindBackButton()
    {
        backButton = GameObject.Find("Back").GetComponent<Button>();
        if (backButton)
        {
            backButton.onClick.AddListener(LoadStartScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == START_SCENE && Input.GetKeyDown(KeyCode.Space))
        {
            LoadMainScene();
        }
    }
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene(START_SCENE, LoadSceneMode.Single);
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(MAIN_SCENE, LoadSceneMode.Single);
    }
    
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(GAME_OVER_SCENE, LoadSceneMode.Single);
    }
    
    // Game does only end, when Player Looses (We don't need WinScene)
    public void LoadWinScene()
    {
        SceneManager.LoadScene(WIN_SCENE, LoadSceneMode.Single);
    }
    
    public void LoadControlsScene()
    {
        SceneManager.LoadScene(CONTROLS_SCENE, LoadSceneMode.Single);
    }
    
    public void LoadPointSystemScene()
    {
        SceneManager.LoadScene(POINT_SYSTEM_SCENE, LoadSceneMode.Single);
    }
    
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
}

