using System.Collections.Generic;

namespace InputlockService
{
    public interface IInputLockService
    {
        InputLock LockInput(InputLockTag[] inputLockTags);
        void UnlockInput(InputLock inputLock);

        bool IsTagLocked(InputLockTag tag);
        InputLock LockAllInputs();
        InputLock LockAllExcept(InputLockTag[] inputLockTagsExcept);
    }
}
