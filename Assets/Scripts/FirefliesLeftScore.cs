using UnityEngine;
using UnityEngine.UI;

public class FirefliesLeftScore : MonoBehaviour
{
    private static Text firefliesLeftText;
    
    private void Start()
    {
        firefliesLeftText = GetComponent<Text>();
        UpdateFirefliesLeftScore();
    }
    
    public static void UpdateFirefliesLeftScore()
    {
        firefliesLeftText.text = Lamp.FirefliesLeft.ToString();
    }
}
