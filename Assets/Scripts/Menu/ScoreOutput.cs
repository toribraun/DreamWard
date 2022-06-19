using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreOutput : MonoBehaviour
{
    [SerializeField] private Text time;
    [SerializeField] private Text bestTime;
    
    void Start()
    {
        var levelName = PlayerPrefs.GetString("lastLevel");
        time.text = TimeToString(PlayerPrefs.GetFloat($"lastLevelScore"));
        bestTime.text = TimeToString(PlayerPrefs.GetFloat($"{levelName}HighScore"));
    }
    
    public static string TimeToString(float time)
    {
        var minutes = Mathf.RoundToInt(time) / 60;
        var seconds = Mathf.RoundToInt(time - minutes * 60);
        var secondsText = seconds < 10 ? $"0{seconds}" : $"{seconds}";
        return $"{minutes}:{secondsText}";
    }
}
