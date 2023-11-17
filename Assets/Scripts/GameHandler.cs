using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;

    public static event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs: EventArgs
    {
        public GameState state;
    }
    
    public enum GameState
    {
        Menu,
        Question,
        Answer,
        Results
    }

    private GameState currentState;
    private bool isEndGame;

    private void Awake()
    {
        Instance = this;
    }
    
    private void ChangeState(GameState newState)
    {
        currentState = newState;
        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{state = newState});
    }
    
    public void NextState()
    {
        switch (currentState)
        {
            case GameState.Menu:
                ChangeState(GameState.Question);
                break;
            case GameState.Question:
                ChangeState(GameState.Answer);
                break;
            case GameState.Answer:
                ChangeState(isEndGame ? GameState.Results : GameState.Question);
                break;
            case GameState.Results:
                isEndGame = false;
                ChangeState(GameState.Menu);
                break;
        }
    }

    public void EndGame()
    {
        isEndGame = true;
    }


    

}
