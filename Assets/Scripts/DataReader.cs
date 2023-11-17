using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataReader
{
    public static Question[] ReadJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/Questions1.json");

        return JsonUtility.FromJson<QuestionData>("{\"questions\": " + json + "}").questions;
    }
}
