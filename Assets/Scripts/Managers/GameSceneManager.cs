using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    // Start is called before the first frame update
    void Start()
    {
        
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
    
    public void LoadMainScene()
    {
        SceneManager.LoadScene(MAIN_SCENE, LoadSceneMode.Single);
        
    }
}
