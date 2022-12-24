using UnityEngine;
using UnityEngine.UI;

namespace InputlockService.Lockables
{
    [RequireComponent(typeof(Button))]
    public class ButtonInputLocker : BaseInputLockable
    {
        private Button _button;

        protected override void Awake()
        {
            _button = GetComponent<Button>();
            base.Awake();
        }
        
        protected override void LockInternal()
        {
            _button.enabled = false;
        }

        protected override void UnlockInternal()
        {
            _button.enabled = true;
        }
    }
}