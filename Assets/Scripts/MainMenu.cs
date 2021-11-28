using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene(GameStates.CurrentLevel);
        GameStates.IsPaused = false;
    }

    public void StartGame(string currentLevel)
    {
        GameStates.CurrentLevel = currentLevel;
        GameStates.IsWonCurrentLevel = false;
        SceneManager.LoadScene(GameStates.CurrentLevel);
        GameStates.IsPaused = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameStates.IsPaused = false;
    }
}