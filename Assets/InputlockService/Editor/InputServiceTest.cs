using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace InputlockService.Editor
{
    public class InputServiceTest
    {
        private InputLockService _inputLockService;

        [SetUp]
        public void Setup()
        {
            _inputLockService = new InputLockService();
        }
    
        [Test]
        public void LockInputTest()
        {
            var lockTags = new List<InputLockTag>() { InputLockTag.Cube };
            _inputLockService.LockInput(lockTags);
        

            Assert.True(_inputLockService.IsTagLocked(InputLockTag.Cube));
        }
    
        [Test]
        public void LockInputUnlockTest()
        {
            var lockTags = new List<InputLockTag>() { InputLockTag.Cube };
            var inputLock = _inputLockService.LockInput(lockTags);
            _inputLockService.UnlockInput(inputLock);

            Assert.False(_inputLockService.IsTagLocked(InputLockTag.Cube));
        }
    
        [Test]
        public void TwoLocksOneUnlockTest()
        {
            var lockTags1 = new List<InputLockTag>() {InputLockTag.Cube};
            var lockTags2 = new List<InputLockTag>() { InputLockTag.Cube };

            var inputLock1 = _inputLockService.LockInput(lockTags1);
            var inputLock2 = _inputLockService.LockInput(lockTags2);

            _inputLockService.UnlockInput(inputLock1);

            Assert.True(_inputLockService.IsTagLocked(InputLockTag.Cube));
        }
        
        [Test]
        public void LockAllInputs()
        {
            _inputLockService.LockAllInputs();
            var inputLockTags = Enum.GetValues(typeof(InputLockTag)).OfType<InputLockTag>().ToList();
            var areAllTagsLocked = true;
            foreach (var tag in inputLockTags)
            {
                areAllTagsLocked = _inputLockService.IsTagLocked(tag) && areAllTagsLocked;
            }
            Assert.True(areAllTagsLocked);
        }
        
        [Test]
        public void LockAllInputsExcept()
        {
            _inputLockService.LockAllExcept(new List<InputLockTag>() { InputLockTag.Cube });
            var inputLockTags = Enum.GetValues(typeof(InputLockTag)).OfType<InputLockTag>().ToList();
            inputLockTags.Remove(InputLockTag.Cube);
            var areAllTagsLocked = true;
            foreach (var tag in inputLockTags)
            {
                areAllTagsLocked = _inputLockService.IsTagLocked(tag) && areAllTagsLocked;
            }
            Assert.True(areAllTagsLocked && !_inputLockService.IsTagLocked(InputLockTag.Cube));
        }
        
    }
}
