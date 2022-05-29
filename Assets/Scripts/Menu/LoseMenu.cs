using System;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    class LoseMenu : MonoBehaviour
    {
        public void Restart()
        {
            MenuController.RestartGame();
        }

        public void GoToMenu()
        {
            MenuController.LoadLevelsMenu();
        }
    }
}
