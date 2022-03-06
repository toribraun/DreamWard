﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarknessLevel : LevelManager
{
    private Lamp lamp;
    private Firefly[] fireflies;
    public Firefly GatheredFirefly;
    
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;
    [SerializeField] private float topBorder;
    [SerializeField] private float bottomBorder;
    
    private void Start()
    {
        StartLevel();
        
        camera.LeftBorder = leftBorder; 
        camera.RightBorder = rightBorder;
        camera.TopBorder = topBorder;
        camera.BottomBorder = bottomBorder;

        player.LevelManager = this;

        fireflies = FindObjectsOfType<Firefly>();
        foreach (var firefly in fireflies)
        {
            firefly.LevelManager = this;
        }
        
        lamp = FindObjectOfType<Lamp>();
        lamp.LevelManager = this;
        lamp.FirefliesLeft = fireflies.Length;
    }

    public override void Win()
    {
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        lamp.animator.Play("Finish");
        lamp.animator.SetBool("Finished", true);
        var cameraAnimator = camera.GetComponentInChildren<Animator>();
        cameraAnimator.Play("CameraLight");
        yield return new WaitForSeconds(10F);
        SceneManager.LoadScene("MenuWin");
    }
    
    
}