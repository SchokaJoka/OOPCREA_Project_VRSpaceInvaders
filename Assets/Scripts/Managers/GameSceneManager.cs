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
    
    public void CheckAllEnemiesDestroyed()
    {
        Debug.Log("Checking if all enemies destroyed");
        
        GameObject enemyParent = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyParent != null && enemyParent.transform.childCount == 0)
        {
            Debug.Log("All enemies destroyed...Loading Win Scene");
            Destroy(enemyParent);
            LoadWinScene();
        }
        

    }
    
    /*public void CheckAllEnemiesDestroyed()
    {
        Debug.Log("Checking if all enemies destroyed");
        
        int octopusCount = GameObject.FindGameObjectsWithTag("Octopus").Length;
        int crabCount = GameObject.FindGameObjectsWithTag("Crab").Length;
        int squidCount = GameObject.FindGameObjectsWithTag("Squid").Length;
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        Debug.Log($"Octopus count: {octopusCount}");
        Debug.Log($"Crab count: {crabCount}");
        Debug.Log($"Squid count: {squidCount}");

        if (enemyCount == 0)
        {
            LoadWinScene();
        }
        
        /*if (octopusCount == 0 && crabCount == 0 && squidCount == 0)
        {
            Debug.Log("All enemies destroyed...Loading Win Scene");
            LoadWinScene();
        }
    }*/

}

