using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool upInput, rightInput, downInput, leftInput, pauseInput, testInput;
        
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
        _playerControls.ActionKey.Up.started += i => upInput = true;
        _playerControls.ActionKey.Right.started += i => rightInput = true;
        _playerControls.ActionKey.Down.started += i => downInput = true;
        _playerControls.ActionKey.Left.started += i => leftInput = true;
        
        _playerControls.ActionKey.Pause.started += i => pauseInput = true;
        
        _playerControls.TestKey.Space.started += i => testInput = true;
    }

    private static void ResetButtons()
    {
        upInput = false;
        rightInput = false;
        downInput = false;
        leftInput = false;

        pauseInput = false;
        
        testInput = false;
    }
}