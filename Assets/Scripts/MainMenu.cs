using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene(GameStates.CurrentLevel);
        PauseMenu.IsPaused = false;
    }

    public void StartGame(string currentLevel)
    {
        GameStates.CurrentLevel = currentLevel;
        GameStates.IsWonCurrentLevel = false;
        SceneManager.LoadScene(GameStates.CurrentLevel);
        PauseMenu.IsPaused = false;
    }
}