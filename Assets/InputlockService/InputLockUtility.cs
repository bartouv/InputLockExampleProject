using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InputlockService
{
   public class InputLockUtility : MonoBehaviour
   {
      [Inject] private IInputLockService _inputLockService;
      private List<InputLock> _allInputInputLock = new();
      
      public void LockAllInput()
      {
         _allInputInputLock?.Add(_inputLockService.LockAllInputs());
      }

      public void LockGuiRaycaster()
      {
         LockSomeInput(new List<InputLockTag> { InputLockTag.GuiRaycaster });
      }
      
      public void LockPhysicsRaycaster()
      {
         LockSomeInput(new List<InputLockTag> { InputLockTag.PhysicsRaycaster });
      }
      
      public void LockCube()
      {
         LockSomeInput(new List<InputLockTag> { InputLockTag.Cube });
      }
      
      public void LockSphere()
      {
         LockSomeInput(new List<InputLockTag> { InputLockTag.Sphere });
      }

      public void UnlockAllInput()
      {
         foreach (var inputLock in _allInputInputLock)
         {
            _inputLockService.UnlockInput(inputLock);
         }
      }

      private void LockSomeInput(List<InputLockTag> tags)
      {
         _allInputInputLock?.Add(_inputLockService.LockInput(tags));
      }

      private InputLock _inputLock;
   }
}
