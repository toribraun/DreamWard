using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField]
    private GameObject levelInfoList;
    [SerializeField]
    private Button Next;
    [SerializeField]
    private Button Previous;
    [SerializeField]
    private GameObject LevelPageGO;
    [SerializeField]
    private GameObject ResultPageGO;
    [SerializeField]
    private GameObject TextGO;
    [SerializeField]
    private GameObject Controller;
    [SerializeField]
    private Text bestTime;
    
    [SerializeField] private Text threshold2;
    [SerializeField] private Text threshold3;

    private Text text;
    private Image levelImage;
    private Image levelResultImage;
    public int currentLevelId = 0;
    private bool[] levelsAvailable;
    private LevelInfo[] levels;

    private bool NextLevelAvailable 
    { 
        get { return (currentLevelId + 1 < levels.Length) && levelsAvailable[currentLevelId + 1]; }
    }
    private bool PreviousLevelAvailable
    {
        get { return (currentLevelId > 0) && levelsAvailable[currentLevelId - 1]; }
    }

    private void Start()
    {
        text = TextGO.GetComponent<Text>();
        levelImage = LevelPageGO.GetComponent<Image>();
        levelResultImage = ResultPageGO.GetComponent<Image>();

        levels = levelInfoList.GetComponentsInChildren<LevelInfo>().OrderBy(lv => lv.Id).ToArray();
        levelsAvailable = new bool[levels.Length];
        levelsAvailable[0] = true;

        // PlayerPrefs.DeleteAll();
        for (var i = 0; i < levels.Length; i++)
        {
            var highScore = PlayerPrefs.GetFloat(levels[i].LevelName + "HighScore");
            Debug.Log($"{levels[i].LevelName + "HighScore"} is {highScore}");
            // var result = highScore > 0 & highScore < 3500;
            var result = highScore > 0;
            //Debug.Log($"Result is {result}");
            if (i < levels.Length - 1)
            {
                levelsAvailable[i + 1] = result;
                currentLevelId = result ? i+1 : currentLevelId;
            }
        }
        SetLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChooseNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChoosePreviousLevel();
        }
    }

    public void StartCurrentLevel()
    {
        MenuController.StartGame(levels[currentLevelId].LevelName);
    }

    public void ChooseNextLevel()
    {
        if (NextLevelAvailable) currentLevelId++;
        SetLevel();
    }

    public void ChoosePreviousLevel()
    {
        if (PreviousLevelAvailable) currentLevelId--;
        SetLevel();
    }

    public void SetLevel()
    {
        levelImage.sprite = levels[currentLevelId].LevelPicture;
        text.text = levels[currentLevelId].LevelText;
        var highScore = PlayerPrefs.GetFloat(levels[currentLevelId].LevelName + "HighScore");
        bestTime.text = highScore == 0 ? "" : $"Best time: {ScoreOutput.TimeToString(highScore)}";
        threshold2.text = ScoreOutput.TimeToString(levels[currentLevelId].threshold2 - 1);
        threshold3.text = ScoreOutput.TimeToString(levels[currentLevelId].threshold3 - 1);
        Previous.interactable = PreviousLevelAvailable;
        Next.interactable = NextLevelAvailable;

        var playerHighscore = PlayerPrefs.GetFloat(levels[currentLevelId].LevelName + "HighScore");

        if (playerHighscore > 0)
        {
            if (playerHighscore <= levels[currentLevelId].threshold3)
                levelResultImage.sprite = levels[currentLevelId].LevelWonPicture3;
            else if (playerHighscore <= levels[currentLevelId].threshold2)
                levelResultImage.sprite = levels[currentLevelId].LevelWonPicture2;
            else
                levelResultImage.sprite = levels[currentLevelId].LevelWonPicture1;
        }
        else
        {
            levelResultImage.sprite = levels[currentLevelId].LevelLostPicture;
        }
    }

    public void Return() 
    {
        MenuController.LoadMainMenu();
    }
}