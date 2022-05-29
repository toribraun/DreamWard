using System;
using UnityEngine;
using UnityEngine.SceneManagement;

class MenuController : MonoBehaviour
{
    public static MenuController instance { get; private set; }
    public static int levelToLoad = 0;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public static void RestartGame()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene(GameStates.CurrentLevel);
        GameStates.IsPaused = false;
    }

    public static void StartGame(string currentLevel)
    {
        GameStates.CurrentLevel = currentLevel;
        GameStates.IsWonCurrentLevel = false;
        SceneManager.LoadScene(GameStates.CurrentLevel);
        GameStates.IsPaused = false;
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameStates.IsPaused = false;
    }

    public static void ResetPlayerData()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void LoadLevelsMenu()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
}
