using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }
    
    // Scene Names
    private readonly string START_SCENE = "Start";
    private readonly string MAIN_SCENE = "Main";
    private readonly string GAME_OVER_SCENE = "GameOver";
    private readonly string CONTROLS_SCENE = "Controls";
    private readonly string POINT_SYSTEM_SCENE = "PointSystem";

    // Buttons
    public Button playButton;
    public Button controlsButton;
    public Button pointsButton;
    public Button backButton;
    public Button playAgainButton;
    public Button exitButton;
    
    public void Awake()
    {
        // Ensure that there is only one GameSceneManager
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        DontDestroyOnLoad(gameObject);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        // Set the Start Scene to be always the first Scene
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != START_SCENE)
        {
            SceneManager.LoadScene(START_SCENE, LoadSceneMode.Single);
        }
    }
    
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Loading Buttons for each time a Scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == START_SCENE)
        {
            FindPlayButton();
            FindControlsButton();
            FindPointSystemButton();
        }
        else if (scene.name == CONTROLS_SCENE || scene.name == POINT_SYSTEM_SCENE)
        {
            FindBackButton();
        }
        else if (scene.name == GAME_OVER_SCENE)
        {
            FindPlayAgainButton();
            FindExitButton();
        }
        else if (scene.name == MAIN_SCENE)
        {
            GameManager.Instance.CheckNumbersOfEnemies();
        }
    }
    
    // Button Finders
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
    private void FindPlayAgainButton()
    {
        playAgainButton = GameObject.Find("PlayAgain").GetComponent<Button>();
        if (playAgainButton)
        {
            playAgainButton.onClick.AddListener(LoadMainScene);
        }
    }
    private void FindExitButton()
    {
        exitButton = GameObject.Find("Exit").GetComponent<Button>();
        if (exitButton)
        {
            exitButton.onClick.AddListener(LoadStartScene);
        }
    }
    
    // Scene Loader
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
    public void LoadControlsScene()
    {
        SceneManager.LoadScene(CONTROLS_SCENE, LoadSceneMode.Single);
    }
    public void LoadPointSystemScene()
    {
        SceneManager.LoadScene(POINT_SYSTEM_SCENE, LoadSceneMode.Single);
    }
}

