using System.IO;
using Player;
using UnityEngine;

namespace Interactable
{
    public class ItemInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string itemName;
        [SerializeField] private string interactText;
        [SerializeField] private int itemQuantity;

        private void GainItem()
        {
            try
            {
                PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
                playerBag.AddItem(itemName, itemQuantity);
            }
            catch (IOException e)
            {
                Debug.LogError(e.Message);
            }
        }

        public void Interact()
        {
            GainItem();
            gameObject.SetActive(false);
        }

        public string GetInteractText()
        {
            return interactText;
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}