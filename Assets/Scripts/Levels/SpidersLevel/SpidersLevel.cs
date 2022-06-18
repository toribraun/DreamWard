using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpidersLevel : LevelManager
{
    [SerializeField]
    private string levelName = "SpidersLevel";
    private WebSpider[] webSpiders;
    
    [HideInInspector]
    public int SpidersLeftCount;
    
    [SerializeField] private float leftBorder; // -100
    [SerializeField] private float rightBorder; //650
    [SerializeField] private float topBorder; //150
    [SerializeField] private float bottomBorder; //-100
    
    private void Start()
    {
        StartLevel();
        
        camera.LeftBorder = leftBorder; 
        camera.RightBorder = rightBorder;
        camera.TopBorder = topBorder;
        camera.BottomBorder = bottomBorder;

        player.LevelManager = this;

        webSpiders = FindObjectsOfType<WebSpider>();
        SpidersLeftCount = webSpiders.Length;
        foreach (var webSpider in webSpiders)
        {
            webSpider.LevelManager = this;
        }
    }

    public override void Win()
    {
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        GameStates.IsWonCurrentLevel = true;
        scoreCounter.SaveHighScore(levelName);
        yield return new WaitForSeconds(5F);
        SceneManager.LoadScene("MenuWin");
    }
}