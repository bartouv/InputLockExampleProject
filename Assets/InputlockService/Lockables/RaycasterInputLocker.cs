using UnityEngine;
using UnityEngine.EventSystems;

namespace InputlockService.Lockables
{
    [RequireComponent(typeof(BaseRaycaster))]
    public class RaycasterInputLocker : BaseInputLockable
    {
        private BaseRaycaster _baseRaycaster;

        protected override void Awake()
        {
            _baseRaycaster = GetComponent<BaseRaycaster>();
            base.Awake();
        }
        
        protected override void LockInternal()
        {
            _baseRaycaster.enabled = false;
        }

        protected override void UnlockInternal()
        {
            _baseRaycaster.enabled = true;
        }
    }
}