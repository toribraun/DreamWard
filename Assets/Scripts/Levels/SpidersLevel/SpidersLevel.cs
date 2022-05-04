using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpidersLevel : LevelManager
{
    private string levelName = "SpidersLevel";
    private WebSpider[] webSpiders;
    
    [HideInInspector]
    public int SpidersLeftCount;
    
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
        scoreCounter.SaveHighScore(levelName);
        yield return new WaitForSeconds(5F);
        SceneManager.LoadScene("MenuWin");
    }
}