using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InputlockService.Lockables
{
    public abstract class BaseInputLockable : MonoBehaviour
    {
        [SerializeField] public List<InputLockTag> Tags;
        private IInputLockServiceSubscription _inputLockServiceSubscription;
        public bool IsLocked { get; private set; }

        [Inject]
        private void Inject(IInputLockServiceSubscription inputLockServiceSubscription)
        {
            _inputLockServiceSubscription = inputLockServiceSubscription;
        }
        protected virtual void Awake()
        {
            _inputLockServiceSubscription.SubscribeLockable(this);
        }

        public void Lock()
        {
            if (IsLocked) return;
            LockInternal();
            IsLocked = true;
        }

        public void Unlock()
        {
            if (!IsLocked) return;
            UnlockInternal();
            IsLocked = false;
        }
        
        private void OnDestroy()
        {
            _inputLockServiceSubscription.UnsubscribeLockable(this);
        }
        
        protected abstract void LockInternal();
        protected abstract void UnlockInternal();
    }
}