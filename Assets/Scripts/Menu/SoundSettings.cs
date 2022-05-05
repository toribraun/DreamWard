using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField]
    private Button currentState;
    [SerializeField]
    private Button nextState;
    //[SerializeField]
    private Button button;

    private void Start()
    {
        button = currentState;
        nextState.gameObject.SetActive(false);
        if (!AudioListener.pause) return;
        ChangeButton();
    }

    public void Switch()
    {
        AudioListener.pause = !AudioListener.pause;
        ChangeButton();
    }

    private void ChangeButton()
    {
        button.interactable = false;
        nextState.gameObject.SetActive(true);
        button = nextState;
        button.interactable = true;
        button.Select();
        currentState.gameObject.SetActive(false);
        nextState = currentState;
        currentState = button;
    }
}
