using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // public static bool IsPaused;
    
    public GameObject pauseMenuUI;

    void Update()
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
        ChangeState(false, 1f);
    }

    public void Pause()
    {
        ChangeState(true, 0f);
    }

    private void ChangeState(bool state, float timeScale)
    {
        pauseMenuUI.SetActive(state);
        Time.timeScale = timeScale;
        GameStates.IsPaused = state;
    }
}
