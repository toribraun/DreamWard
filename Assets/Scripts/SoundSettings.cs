using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField]
    private Sprite currentStateImage;
    [SerializeField]
    private Sprite nextStateImage;
    [SerializeField]
    private Button button;

    private void Start()
    {
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
        currentStateImage = button.image.sprite;
        button.image.sprite = nextStateImage;
        button.interactable = false;
        button.interactable = true;
        nextStateImage = currentStateImage;
    }
}
