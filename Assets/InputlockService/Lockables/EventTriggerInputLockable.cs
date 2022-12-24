
using UnityEngine.EventSystems;

namespace InputlockService.Lockables
{
    public class EventTriggerInputLockable : BaseInputLockable
    {
        private EventTrigger _eventTrigger;
        
        protected override void Awake()
        {
            _eventTrigger = GetComponent<EventTrigger>();
            base.Awake();
        }
        
        protected override void LockInternal()
        {
            _eventTrigger.enabled = false;
        }

        protected override void UnlockInternal()
        {
            _eventTrigger.enabled = true;
        }
    }
}
