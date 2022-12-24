using UnityEditor;

namespace InputlockService.Editor
{
    /*
    public class InputLockEditorWindow : OdinEditorWindow
    {
         private static InputLockService _inputLockService;
         [TableList(AlwaysExpanded = true, HideToolbar = true)] public InputLockButton[] InputLockButtons;

        public void OnInspectorUpdate()
        {
            if (InputLockService._inputLockService == null) return;
            _inputLockService = InputLockService._inputLockService;
            _inputLockService.LocksUpdated -= GenerateSceneLoadButtons;
            _inputLockService.LocksUpdated += GenerateSceneLoadButtons;
        }
        
        [MenuItem("Tools/InputLockEditorWindow _%i")]
        private static void OpenWindow()
        {
            GetWindow<InputLockEditorWindow>().Show();
        }
        
        
        private void GenerateSceneLoadButtons()
        {
            var inputLocks = _inputLockService.GetInputLocks();
            var inputLockButtons = new InputLockButton[inputLocks.Count];

            for (var i = 0; i < inputLocks.Count; i++)
            {
                var inputLock = inputLocks[i];
                inputLockButtons[i] = new InputLockButton($"{inputLock.LockOwner}: {inputLock}");
            }

            InputLockButtons = inputLockButtons;
            Repaint();
        }
    }

    
    public class InputLockButton
    {
        private string _buttonName;

        public InputLockButton(string callerName)
        {
            _buttonName = callerName;
        }

        [GUIColor(.36f, 0.42f, 0.68f , 1)]
        [Button("$_buttonName", ButtonSizes.Large)]
        public void OpenScene()
        {
            
        }
    }
    */
    
}
