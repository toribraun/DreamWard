using UnityEngine;


public class ScoreCounter : MonoBehaviour
{
    public float time;
    
    private void Start()
    {
        time = 0f;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void SaveHighScore(string levelName)
    {
        var keyName = levelName + "HighScore";
        var storedSCore = PlayerPrefs.GetFloat(keyName);
        Debug.Log($"The score is {time})");
        Debug.Log($"The stored score is {storedSCore}");
        if (storedSCore == 0 | storedSCore > time)
            PlayerPrefs.SetFloat(keyName, time);
        Debug.Log($"After saving the stored score is {PlayerPrefs.GetFloat(keyName)}");
        PlayerPrefs.SetString("lastLevel", levelName);
        PlayerPrefs.SetFloat("lastLevelScore", time);
    }
}