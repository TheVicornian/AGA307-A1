using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState state;
    public TargetDifficulty difficulty;
    int scoreMultiplier = 1;
    int score = 1;


    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Start;
        Setup();
        EventManager.EnemyHit -= EnemyHit;
    }

    void OnDestroy()
    {
        EventManager.EnemyHit -= EnemyHit;
    }

    void EnemyHit(Enemy e)
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

    public void AddScore(int addScore)
    {
        score += addScore * scoreMultiplier;

    }
}
