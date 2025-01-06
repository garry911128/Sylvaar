using AVG;
using UnityEngine;

namespace Core
{
    public class TriggerMainStory : MonoBehaviour
    {
        [SerializeField] protected string scriptPath;
        [SerializeField] private bool isRetriggerable = false;
        private bool hasTriggered = false;

        private void Start()
        {
            TriggerAVG();
        }

        private void Update()
        {

        }
        public void TriggerAVG()
        {
            if (AVGMachine.Instance.IsFinished()
                && (!hasTriggered || isRetriggerable))
            {
                hasTriggered = true;
                 Debug.Log("Trigger AVG");
                AVGMachine.Instance.LoadFromCSV(scriptPath, "MainStory");
                AVGMachine.Instance.Play();
            }
        }

        public bool GetHasTriggered()
        {
            return hasTriggered;
        }

        public void ResetTrigger()
        {
            hasTriggered = false;
        }
    }
}