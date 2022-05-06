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
    private Button Next;
    [SerializeField]
    private Button Previous;
    [SerializeField]
    private List<Button> buttonsChain = new List<Button>();
    public int currentLevelId = 0;
    private bool[] levelsAvailable;

    private bool NextLevelAvailable 
    { 
        get { return (currentLevelId + 1 < buttonsChain.Count) && levelsAvailable[currentLevelId + 1]; }
    }
    private bool PreviousLevelAvailable
    {
        get { return (currentLevelId > 0) && levelsAvailable[currentLevelId - 1]; }
    }

    private void Start()
    {
        levelsAvailable = new bool[buttonsChain.Count];
        levelsAvailable[0] = true;
        // PlayerPrefs.DeleteAll();
        for (var i = 0; i < buttonsChain.Count; i++)
        {
            buttonsChain[i].gameObject.SetActive(false);
            var highScore = PlayerPrefs.GetInt(levelsChain[i] + "HighScore");
            //Debug.Log($"{levelsChain[i] + "HighScore"} is {highScore}");
            var result = highScore > 0 & highScore < 3000;
            //Debug.Log($"Result is {result}");
            if (i < buttonsChain.Count - 1)
            {
                levelsAvailable[i + 1] = result;
            }
        }
        buttonsChain[currentLevelId].gameObject.SetActive(true);
        Next.interactable = NextLevelAvailable;
        Previous.interactable = PreviousLevelAvailable;
    }

    public void ChooseNextLevel()
    {
        if (NextLevelAvailable)
        {
            buttonsChain[currentLevelId].gameObject.SetActive(false);
            currentLevelId++;
            buttonsChain[currentLevelId].gameObject.SetActive(true);
        }
        Previous.interactable = PreviousLevelAvailable;
        Next.interactable = NextLevelAvailable;
    }

    public void ChoosePreviousLevel()
    {
        if (PreviousLevelAvailable)
        {
            buttonsChain[currentLevelId].gameObject.SetActive(false);
            currentLevelId--;
            buttonsChain[currentLevelId].gameObject.SetActive(true);
            Next.interactable = NextLevelAvailable;
        }
        Previous.interactable = PreviousLevelAvailable;
        Next.interactable = NextLevelAvailable;
    }
}