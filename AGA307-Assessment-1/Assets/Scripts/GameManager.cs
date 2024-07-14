using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameState state;
    public TargetDifficulty difficulty;

    int scoreMultiplier = 1;   
    static public int score = 0;
    public GameObject scoreText;

    public GameObject pauseScreen;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Start;
        Setup();

        EventManager.EnemyHit += OnEnemyHit;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString();
    }

    void OnDestroy()
    {
        EventManager.EnemyHit -= OnEnemyHit;
       
    }

    public void AddScore(int addScore)
    {
        score += addScore * scoreMultiplier;

    }
    void OnEnemyHit(Enemy e)
    {
        AddScore(10);
    }

    void Setup()
    {
        switch (difficulty)
        {
            case TargetDifficulty.Easy:
                scoreMultiplier = 1;
                break;

            case TargetDifficulty.Medium:
                scoreMultiplier = 2;
                break;

            case TargetDifficulty.Hard:
                scoreMultiplier = 3;
                break;

            default:
                scoreMultiplier = 1;
                break;

        }

    }
    public void TogglePause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        pauseScreen.SetActive(paused);
    }

}