using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class LevelManager : MonoBehaviour
{
    public Cat player;
    public FollowCamera camera;
    public ScoreCounter scoreCounter;
    public int Level = 1; 
    
    public void StartLevel()
    {
        SetPlayerObject();
        SetCamera();
        SetScoreCounter();
    }
    
    private void SetPlayerObject()
    {
        if (!player)
            player = FindObjectOfType<Cat>();
    }

    private void SetCamera()
    {
        if (camera) 
            return;
        camera = FindObjectOfType<FollowCamera>();
        if (!player)
            SetPlayerObject();
        camera.player = player.transform;
    }

    private void SetScoreCounter()
    {
        if (!scoreCounter)
            scoreCounter = gameObject.AddComponent<ScoreCounter>();
    }

    public virtual void Win()
    {
        SceneManager.LoadScene("MenuWin");
    }

    public virtual void Lose()
    {
        SceneManager.LoadScene("MenuLose");
    }
}