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
         LockSomeInput( new[] { InputLockTag.GuiRaycaster });
      }
      
      public void LockPhysicsRaycaster()
      {
         LockSomeInput( new[] { InputLockTag.PhysicsRaycaster });
      }
      
      public void LockCube()
      {
         LockSomeInput( new[] { InputLockTag.Cube });
      }
      
      public void LockSphere()
      {
         LockSomeInput( new[] { InputLockTag.Sphere });
      }

      public void UnlockAllInput()
      {
         foreach (var inputLock in _allInputInputLock)
         {
            _inputLockService.UnlockInput(inputLock);
         }
      }

      private void LockSomeInput(InputLockTag[] tags)
      {
         _allInputInputLock?.Add(_inputLockService.LockInput(tags));
      }

      private InputLock _inputLock;
   }
}
