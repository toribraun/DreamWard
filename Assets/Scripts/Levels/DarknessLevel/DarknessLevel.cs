using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarknessLevel : LevelManager
{
    [SerializeField]
    private string levelName = "DarknessLevel";
    
    private Lamp lamp;
    private Timer timer;
    [HideInInspector]
    public Firefly[] fireflies;
    public Firefly GatheredFirefly;
    
    [SerializeField] private float leftBorder; // -56
    [SerializeField] private float rightBorder; //810
    [SerializeField] private float topBorder; //200
    [SerializeField] private float bottomBorder; //-40

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
        
        timer = FindObjectOfType<Timer>();
        timer.time = Level switch
        {
            3 => 420F,
            _ => 300F
        };
    }

    public override void Win()
    {
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        scoreCounter.SaveHighScore(levelName);
        lamp.animator.Play("Finish");
        lamp.animator.SetBool("Finished", true);
        var cameraAnimator = camera.GetComponentInChildren<Animator>();
        cameraAnimator.Play("CameraLight");
        yield return new WaitForSeconds(10F);
        SceneManager.LoadScene("MenuWin");
    } 
}