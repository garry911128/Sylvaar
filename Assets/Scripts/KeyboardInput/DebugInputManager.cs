using Player;
using UnityEngine;
using UnityEngine.Events;

namespace KeyboardInput
{
    public class DebugInputManager : MonoBehaviour
    {
        public UnityEvent<string> evtEquipWeapon;
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown("1"))
            {
                evtEquipWeapon?.Invoke("Sword");
            }
            else if (Input.GetKeyDown("2"))
            {
                evtEquipWeapon?.Invoke("Shield");
            }
            else if (Input.GetKeyDown("3"))
            {
                evtEquipWeapon?.Invoke("Bomb");
            }
            else if (Input.GetKeyDown("4"))
            {
                PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
                playerBag.AddItem("Wood", 10);
            }
            else if (Input.GetKeyDown("5"))
            {
                PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
                playerBag.AddItem("Stone", 10);
            }
            else if (Input.GetKeyDown("6"))
            {
                PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
                playerBag.AddItem("YellowKey(L)", 1);
            }
            else if (Input.GetKeyDown("7"))
            {
                PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
                playerBag.AddItem("YellowKey(R)", 1);
            }
            else if (Input.GetKeyDown("8"))
            {
                PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
                playerBag.AddItem("PurpleKey(L)", 1);
            }
            else if (Input.GetKeyDown("9"))
            {
                PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
                playerBag.AddItem("PurpleKey(R)", 1);
            }
        }
    }

}
