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
    
    [SerializeField] private int numberOfQuestions;

    private GameState currentState;

    private int numberOfQuestionsLeft;
    


    private void Awake()
    {
        Instance = this;

        numberOfQuestionsLeft = numberOfQuestions;
    }
    
    
    public void NextState()
    {
        //to do: вынести логику подсчета вопросов?
        switch (currentState)
        {
            case GameState.Menu:
                ChangeState(GameState.Question);
                break;
            case GameState.Question:
                numberOfQuestionsLeft--;
                ChangeState(GameState.Answer);
                break;
            case GameState.Answer:
                ChangeState(numberOfQuestionsLeft > 0 ? GameState.Question : GameState.Results);
                break;
            case GameState.Results:
                numberOfQuestionsLeft = numberOfQuestions;
                ChangeState(GameState.Menu);
                break;
        }
    }

    private void ChangeState(GameState newState)
    {
        currentState = newState;
        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{state = newState});
    }
    

}
