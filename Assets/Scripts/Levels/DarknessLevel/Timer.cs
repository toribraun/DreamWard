using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public Text TimerText;
    private float time = 420F;
    [SerializeField]
    private Cat cat;
    [SerializeField]
    private Lamp lamp;
    
    
    public void Start()
    {
        TimerText.text = ConvertTime(time);
    }

    public void Update()
    {
        if (lamp.FirefliesLeft == 0)
            return;
        if (GameStates.IsPaused)
            return;
        time -= Time.deltaTime;
        if (time > 0)
            TimerText.text = ConvertTime(time);
        else
        {
            cat.Die();
        }
    }

    private string ConvertTime(float time)
    {
        var minutes = Mathf.RoundToInt(time) / 60;
        var seconds = Mathf.RoundToInt(time - minutes * 60);
        var secondsText = seconds < 10 ? $"0{seconds}" : $"{seconds}";
        return $"{minutes}:{secondsText}";
    }
}