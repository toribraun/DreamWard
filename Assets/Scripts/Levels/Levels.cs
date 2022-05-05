using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField]
    private List<string> levelsChain = new List<string>
    {
        "WaterLevel1",
        "SpidersLevel1",
        "DarknessLevel1",
        "WaterLevel2"
    };

    [SerializeField]
    private List<Button> buttonsChain = new List<Button>();

    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        for (var i = 0; i < buttonsChain.Count - 1; i++)
        {
            var highScore = PlayerPrefs.GetInt(levelsChain[i] + "HighScore");
            Debug.Log($"{levelsChain[i] + "HighScore"} is {highScore}");
            var result = highScore > 0 & highScore < 3000;
            Debug.Log($"Result is {result}");
            buttonsChain[i + 1].interactable = result;
            if (result) continue;
            for (var j = i; j < buttonsChain.Count - 1; j++)
            {
                buttonsChain[i + 1].interactable = false;
            }
        }
    }
}