using UnityEngine;

    public class InputManager : MonoBehaviour
    {
        public static bool UpInput, RightInput, DownInput, LeftInput;
        
        private PlayerControls _playerControls;

        private void Awake()
        {
            _playerControls = new PlayerControls();
            
            //Cursor.visible = false;
        }

        private void LateUpdate()
        {
            ResetButtons();
        }

        private void OnEnable()
        {
            if (_playerControls == null) return;

            GetButtonsDown();
                
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }

        private void GetButtonsDown()
        {
            _playerControls.ActionKey.Up.started += i => UpInput = true;
            _playerControls.ActionKey.Right.started += i => RightInput = true;
            _playerControls.ActionKey.Down.started += i => DownInput = true;
            _playerControls.ActionKey.Left.started += i => LeftInput = true;
        }

        private static void ResetButtons()
        {
            UpInput = false;
            RightInput = false;
            DownInput = false;
            LeftInput = false;
        }
    }
