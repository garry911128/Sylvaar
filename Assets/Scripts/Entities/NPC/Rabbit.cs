using System.Collections.Generic;
using Core;
using Interactable;
using Player;
using UnityEngine;

namespace Entities.NPC
{
    public class Rabbit : NPCInteractable
    {
        [SerializeField] private TriggerZoneWithInteract triggerZoneWithInteract;
        [SerializeField] private int missionStoneCount;
        [SerializeField] private int missionWoodCount;
        [SerializeField] private QuestSystem npcQuestSystem;

        private void Start()
        {
            StoryManager.Instance.RegisterNPC("Rabbit");
        }

        public override void Interact()
        {
            if (npcQuestSystem.GetScriptID("rabbit") == 1)
            {
                if (IsMissionDone())
                {
                    npcQuestSystem.SetScriptsID("rabbit", 2);
                    DeleteItem();
                }
                triggerZoneWithInteract.TriggerAVG();
                PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
                playerBag.AddItem("PurpleKey(R)", 1);
            }
            else
            {
                triggerZoneWithInteract.TriggerAVG();
            }
        }

        private bool IsMissionDone()
        {
            Dictionary<string, int> playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>().GetItemCount();
            if (playerBag["Stone"] >= missionStoneCount && playerBag["Wood"] >= missionWoodCount)
            {
                // Get Item And Check Count
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DeleteItem()
        {
            PlayerBag playerBag = GameObject.Find("PlayerBag").GetComponent<PlayerBag>();
            playerBag.RemoveItem("Stone", missionStoneCount);
            playerBag.RemoveItem("Wood", missionWoodCount);
        }
    }
}

