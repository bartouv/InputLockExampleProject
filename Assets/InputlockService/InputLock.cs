using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace InputlockService
{
    public class InputLock
    {
        public readonly string Guid;
        public readonly InputLockTag[] InputLockTags;
        public readonly string LockOwner;

        public InputLock(InputLockTag[] inputLockTags,[CallerFilePath] string callerName = "")
        {
            Guid = System.Guid.NewGuid().ToString();
            InputLockTags = inputLockTags;
            LockOwner = Path.GetFileNameWithoutExtension(callerName);
        }

        public override string ToString()
        {   
            return string.Join( ",", InputLockTags);
        }
    }
}