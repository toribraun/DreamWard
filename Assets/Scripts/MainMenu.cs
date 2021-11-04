using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene(GameStates.CurrentLevel);
    }
}