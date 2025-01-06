using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace KeyboardInput
{
    public class GameEndInputManager : MonoBehaviour
    {
        [SerializeField] private Button restartButton;


        public void OnRestartButtonClicked()
        {
            //Debug.Log("Restart button clicked. Changing game state to InGame.");
            GameManager.Instance.GameStateChange(GameManager.GameState.MainMenu);
        }

    }
}
