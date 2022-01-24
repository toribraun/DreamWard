using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private float time = 15F;
    [SerializeField]
    private string nextScene = "MainMenu";

    public void Start()
    {
    }

    public void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}