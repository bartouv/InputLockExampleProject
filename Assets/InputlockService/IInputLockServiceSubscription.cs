using InputlockService.Lockables;

namespace InputlockService
{
    public interface IInputLockServiceSubscription
    {
        void SubscribeLockable(BaseInputLockable inputLockable);
        void UnsubscribeLockable(BaseInputLockable inputLockable);
    }
}