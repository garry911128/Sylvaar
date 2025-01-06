using System.Collections;
using System.Collections.Generic;
using Core;
using Interactable;
using Player;
using UnityEngine;

namespace Interactable
{
    public class CaveInteract : MonoBehaviour, IInteractable
    {
        public enum CaveType
        {
            Good,
            Bad
        }

        [SerializeField] private CaveType caveType;

        public void Interact()
        {
            PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
            Dictionary<string, int> items = playerBag.GetItemCount();
            if (caveType == CaveType.Good)
            {
                Debug.Log("You entered the good cave. A positive ending awaits!");
                if (items["YellowKey(L)"] >= 1 && items["YellowKey(R)"] >= 1)
                {
                    Debug.Log("You have the keys to open the chest!");
                    GameManager.Instance.GameStateChange(GameManager.GameState.GoodEnd);
                }
                else
                {
                    Debug.Log("You don't have the keys to go to the cave!");
                }
            }
            else if (caveType == CaveType.Bad)
            {
                Debug.Log("You entered the bad cave. Beware of the consequences!");
                if (items["PurpleKey(L)"] >= 1 && items["PurpleKey(L)"] >= 1)
                {
                    Debug.Log("You have the keys to open the chest!");
                    GameManager.Instance.GameStateChange(GameManager.GameState.BadEnd);
                }
                else
                {
                    Debug.Log("You don't have the keys to go to the cave!");
                }
            }
        }

        public string GetInteractText()
        {
            return $"Enter the {caveType} cave";
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}