using System;
using System.Collections.Generic;
using System.Linq;
using InputlockService.Lockables;
using UnityEngine;

namespace InputlockService
{
    public class InputLockService : IInputLockService, IInputLockServiceSubscription
    {
        private readonly Dictionary<InputLockTag, HashSet<string>> _locks = new Dictionary<InputLockTag, HashSet<string>>();
        private readonly Dictionary<string, InputLock> _idToInputLock = new Dictionary<string, InputLock>();
        private readonly HashSet<BaseInputLockable> _inputLockSubscribers = new HashSet<BaseInputLockable>();

#if  UNITY_EDITOR
        public static InputLockService _inputLockService;
        public event Action LocksUpdated;
#endif
        
        public InputLockService()
        {
#if UNITY_EDITOR
            _inputLockService = this;
#endif
            foreach (var tags in Enum.GetValues(typeof(InputLockTag)))
            {
                _locks.Add((InputLockTag)tags, new HashSet<string>());
            }
        }

        public List<InputLock> GetInputLocks()
        {
            return _idToInputLock.Values.ToList();
        }

        public void SubscribeLockable(BaseInputLockable inputLockable)
        {
            if(_inputLockSubscribers.Contains(inputLockable)) return;
            
            _inputLockSubscribers.Add(inputLockable);
            UpdateLockable(inputLockable);
        }

        public void UnsubscribeLockable(BaseInputLockable inputLockable)
        {
            if(!_inputLockSubscribers.Contains(inputLockable)) return;
            
            _inputLockSubscribers.Remove(inputLockable);
        }

        public bool IsTagLocked(InputLockTag tag)
        {
            try
            {
                return _locks[tag].Count > 0;
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.Log($"IsTagLocked {tag.ToString()} is out of bounds");
            }

            return false;
        }

        public InputLock LockAllInputs()
        {
            var inputLockTags = Enum.GetValues(typeof(InputLockTag)).OfType<InputLockTag>().ToList();
            return LockInput(inputLockTags.ToArray());;
        }

        public InputLock LockAllExcept(InputLockTag[] inputLockTagsExcept)
        {
            var inputLockTags = Enum.GetValues(typeof(InputLockTag)).OfType<InputLockTag>().ToList();
            foreach (var exceptionTag in inputLockTagsExcept)
            {
                inputLockTags.Remove(exceptionTag);
            }
            return LockInput(inputLockTags.ToArray());
        }

        public InputLock LockInput(InputLockTag[] inputLockTags)
        {
            var inputLock = new InputLock(inputLockTags);

            foreach (var lockType in inputLock.InputLockTags)
            {
                if (_locks[lockType].Contains(inputLock.Guid))
                {
                    Debug.Log($"The lock {inputLock.Guid} is already locked");
                    return null;
                }

                _locks[lockType].Add(inputLock.Guid);
            }
            _idToInputLock.Add(inputLock.Guid,inputLock);
            UpdateLockables();
        
#if UNITY_EDITOR
            LocksUpdated?.Invoke();
#endif
            return inputLock;
        }

        public void UnlockInput(InputLock inputLock)
        {
            foreach (var lockType in inputLock.InputLockTags)
            {
                if (!_locks[lockType].Contains(inputLock.Guid))
                {
                    Debug.Log($"You are trying to unlock {inputLock.ToString()} but no such inputlock exists");
                    return;
                }

                _locks[lockType].Remove(inputLock.Guid);
            }
            _idToInputLock.Remove(inputLock.Guid);

            UpdateLockables();
#if UNITY_EDITOR
            LocksUpdated?.Invoke();
#endif
        }

        private void UpdateLockables()
        {
            foreach (var inputLockable in _inputLockSubscribers)
            {
                UpdateLockable(inputLockable);
            }
        }

        private void UpdateLockable(BaseInputLockable inputLockable)
        {
            var shouldLock = ShouldLockInputLockable(inputLockable);

            if (shouldLock)
            {
                inputLockable.Lock();
            }
            else
            {
                inputLockable.Unlock();
            }
        }

        private bool ShouldLockInputLockable(BaseInputLockable inputLockable)
        {
            var shouldLock = false;
            foreach (var tag in inputLockable.Tags)
            {
                var isLocked = _locks[tag].Count != 0;
                if (isLocked)
                {
                    shouldLock = true;
                    break;
                }
            }

            return shouldLock;
        }
    }
}