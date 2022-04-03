using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class LevelManager : MonoBehaviour
{
    public Cat player;
    public FollowCamera camera;
    
    public void StartLevel()
    {
        SetPlayerObject();
        SetCamera();
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

    public virtual void Win()
    {
        SceneManager.LoadScene("MenuWin");
    }

    public virtual void Lose()
    {
        SceneManager.LoadScene("Lose");
    }
}