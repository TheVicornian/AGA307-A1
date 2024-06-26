using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state;
    public Difficulty difficulty;
    int scoreMultipler = 1;


    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Start;

        difficulty = Difficulty.Easy;
        Setup();

        
    }

    // Update is called once per frame
    void Update()
    { 
    
    }

    void Setup()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultipler = 1;
                break;
            case Difficulty.Medium:
                scoreMultipler = 2;
                break;
            case Difficulty.Hard:
                scoreMultipler = 3;
                break;
            default:
                scoreMultipler = 1;
                break;

        }

    }
}
