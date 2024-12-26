using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }
    
    private readonly string START_SCENE = "Start";
    private readonly string MAIN_SCENE = "Main";
    private readonly string GAME_OVER_SCENE = "GameOver";
    private readonly string WIN_SCENE = "Win";

    public void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != START_SCENE)
        {
            SceneManager.LoadScene(START_SCENE, LoadSceneMode.Single);
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
    
    public void LoadWinScene()
    {
        SceneManager.LoadScene(WIN_SCENE, LoadSceneMode.Single);
    }
    
}

