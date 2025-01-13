using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    // Variables
    private int numbersOfEnemies;
    private int currentNumbersOfEnemies;
    
    private int persistentScore = 0;
    private int persistentPlayerLives = 3;

    // Unity
    private void Awake()
    {
        CheckForDuplicates();
    }
    private void Start()
    {
        EnemyArmy.OnEnemyDied += CheckRestartCondition;
        PlayerShip.OnPlayerTookDamage += CheckLooseCondition;
        CheckNumbersOfEnemies();
    }
    private void OnDestroy()
    {
        EnemyArmy.OnEnemyDied -= CheckRestartCondition;
        PlayerShip.OnPlayerTookDamage -= CheckLooseCondition;
    }
    
    // Methods
    private void CheckRestartCondition()
    {
        currentNumbersOfEnemies--;
        if (0 >= currentNumbersOfEnemies)
        {
            ScoreDisplay scoreDisplay = FindObjectOfType<ScoreDisplay>();
            PlayerShip playerShip = FindObjectOfType<PlayerShip>();
            if (scoreDisplay != null && playerShip != null)
            {
                persistentScore = scoreDisplay.GetCurrentScore();
                persistentPlayerLives = playerShip.GetCurrentPlayerLifes();
            }
            
            GameSceneManager.Instance.LoadMainScene();
        }
    }
    private void CheckLooseCondition(int currentPlayerLifes)
    {
        if (currentPlayerLifes <= 0)
        {
            ResetPersistentValues();
            GameSceneManager.Instance.LoadGameOverScene();
        }
    }
    public void CheckNumbersOfEnemies()
    {
        numbersOfEnemies = FindObjectsOfType<EnemyShooter>().Length;
        Debug.Log($"GameManager.cs: Found {numbersOfEnemies} Enemys!");
        currentNumbersOfEnemies = numbersOfEnemies;
    }
    private void CheckForDuplicates()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
    public int GetPersistentScore()
    {
        return persistentScore;
    }
    public int GetPersistentPlayerLives()
    {
        return persistentPlayerLives;
    }
    private void ResetPersistentValues()
    {
        persistentScore = 0;
        persistentPlayerLives = 3;
    }
}
