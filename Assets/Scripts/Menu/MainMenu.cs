using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]

    public void ResetPlayerData()
    {
        MenuController.ResetPlayerData();
    }

    public void LoadLevelsMenu()
    {
        MenuController.LoadLevelsMenu();
    }
    public void QuitGame()
    {
        MenuController.QuitGame();
    }
}