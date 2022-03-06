using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WaterLevel : LevelManager
{
    private Valve valve;
    
    [SerializeField] private float cameraHorizontalBorder; // 53
    [SerializeField] private float topBorder; // 600
    [SerializeField] private float bottomBorder;
    
    private void Start()
    {
        StartLevel();
        camera.LeftBorder = camera.RightBorder = cameraHorizontalBorder;
        camera.TopBorder = topBorder;
        camera.BottomBorder = bottomBorder;
        player.LevelManager = this;
        valve = FindObjectOfType<Valve>();
        valve.player = player;
    }

    public override void Win()
    {
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        valve.animator.Play("Finish");
        valve.animator.SetBool("Finished", true);
        var cameraAnimator = camera.GetComponentInChildren<Animator>();
        cameraAnimator.Play("CameraLight");
        yield return new WaitForSeconds(10F);
        SceneManager.LoadScene("MenuWin");
    }

    public override void Lose()
    {
        SceneManager.LoadScene("Lose");
    }
}