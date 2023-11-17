using UnityEngine;

[System.Serializable]
public class QuestionData
{
    public Question[] questions;
}

[System.Serializable]
public class Question
{
    public string text;
    public Answer[] answers;
    public string backgroundFilePath;
}

[System.Serializable]
public class Answer
{
    public string text;
    public bool correct;
}

