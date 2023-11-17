using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataReader
{
    public static Question[] GetQuestionArrayFromJson(string path)
    {
        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<QuestionData>("{\"questions\": " + json + "}").questions;
    }
}
