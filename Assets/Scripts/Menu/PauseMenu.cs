using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private void Start()
    {
        Resume();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (GameStates.IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        SetPauseState(false);
    }

    public void Pause()
    {
        SetPauseState(true);
    }

    public void SetPauseState(bool state)
    {
        pauseMenuUI.SetActive(state);
        Time.timeScale = state ? 0f : 1f;
        GameStates.IsPaused = state;
    }

    public void LoadMenu()
    {
        MenuController.LoadLevelsMenu();
    }
}
