using UnityEngine;


public class ScoreCounter : MonoBehaviour
{
    public float time;
    
    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        time = 0f;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void SaveHighScore(string levelName)
    {
        var score = Mathf.RoundToInt(time * 100);
        var keyName = levelName + "HighScore";
        var storedSCore = PlayerPrefs.GetInt(keyName);
        Debug.Log($"The score is {score})");
        Debug.Log($"The stored score is {storedSCore}");
        if (storedSCore == 0 | storedSCore > Mathf.RoundToInt(score))
            PlayerPrefs.SetInt(keyName, Mathf.RoundToInt(score));
        Debug.Log($"After saving the stored score is {PlayerPrefs.GetInt(keyName)}");
        Levels.needToUpdate = true;
    }
}