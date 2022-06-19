using System;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    class WinMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject textboxGO;

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
