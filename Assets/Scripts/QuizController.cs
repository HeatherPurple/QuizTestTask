using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    public static QuizController Instance;
    
    private Question[] questionArray;
    private int currentQuestionIndex = 0;

    private void Awake()
    {
        Instance = this;
        
        questionArray = DataReader.ReadJson();
    }
    
    public Question GetCurrentQuestion()
    {
        return questionArray[currentQuestionIndex];
    }

    public void AnswerQuestion(bool isCorrect)
    {
        currentQuestionIndex++;
    }
}
