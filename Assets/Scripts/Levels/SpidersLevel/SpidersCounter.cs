using UnityEngine;
using UnityEngine.UI;

public class SpidersCounter : MonoBehaviour
{
    [SerializeField]
    public Text CounterText;
    [SerializeField]
    public SpidersLevel LevelManager;

    public void Update()
    {
        CounterText.text = LevelManager.SpidersLeftCount switch
        {
            0 => "",
            1 => "1 spider left",
            _ => LevelManager.SpidersLeftCount + " spiders left"
        };
    }
}