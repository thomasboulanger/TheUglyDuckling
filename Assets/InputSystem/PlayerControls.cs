// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""ActionKey"",
            ""id"": ""b7c5d798-2618-451b-8ec5-f2d61b00c253"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""697ce9b0-fdfc-4a82-b092-dd2b2d213da1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""9b2c2753-3c4a-41c0-a54a-5e4bfda404a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""7ba58eb0-091d-4aed-96b1-8924d34cf802"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""aaa694d1-6540-4787-852c-fd71efae20e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""75e53db8-850c-49aa-9b4a-a3827374fff4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d63bf6b5-936c-4991-a4e9-6e8aaa798574"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0539883e-6fb0-4c69-a479-9130a00ca53d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad832fa4-e85f-40fa-9000-3b1479097bfb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcd993b4-f70c-46c6-b8aa-cb9d6c27a610"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""889fa163-1aaf-4320-ba04-c8c24a96efcb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0ffe684-5867-48a1-9003-56038a44eb93"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0c32c36-22b0-4652-b42f-19be00e203cb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b2120d4-0b17-46ad-8293-4ec217d6f6db"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df30a5f7-ef71-43df-b4de-e8f0e0f8ae13"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TestKey"",
            ""id"": ""f2951b38-61a0-474f-91ed-47e0adec5a8b"",
            ""actions"": [
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""eb052f33-17cc-4500-8970-e4fc28e787c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3abd1942-c150-438e-a02e-b75982f97da3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ActionKey
        m_ActionKey = asset.FindActionMap("ActionKey", throwIfNotFound: true);
        m_ActionKey_Up = m_ActionKey.FindAction("Up", throwIfNotFound: true);
        m_ActionKey_Right = m_ActionKey.FindAction("Right", throwIfNotFound: true);
        m_ActionKey_Down = m_ActionKey.FindAction("Down", throwIfNotFound: true);
        m_ActionKey_Left = m_ActionKey.FindAction("Left", throwIfNotFound: true);
        m_ActionKey_Pause = m_ActionKey.FindAction("Pause", throwIfNotFound: true);
        // TestKey
        m_TestKey = asset.FindActionMap("TestKey", throwIfNotFound: true);
        m_TestKey_Space = m_TestKey.FindAction("Space", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // ActionKey
    private readonly InputActionMap m_ActionKey;
    private IActionKeyActions m_ActionKeyActionsCallbackInterface;
    private readonly InputAction m_ActionKey_Up;
    private readonly InputAction m_ActionKey_Right;
    private readonly InputAction m_ActionKey_Down;
    private readonly InputAction m_ActionKey_Left;
    private readonly InputAction m_ActionKey_Pause;
    public struct ActionKeyActions
    {
        private @PlayerControls m_Wrapper;
        public ActionKeyActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_ActionKey_Up;
        public InputAction @Right => m_Wrapper.m_ActionKey_Right;
        public InputAction @Down => m_Wrapper.m_ActionKey_Down;
        public InputAction @Left => m_Wrapper.m_ActionKey_Left;
        public InputAction @Pause => m_Wrapper.m_ActionKey_Pause;
        public InputActionMap Get() { return m_Wrapper.m_ActionKey; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionKeyActions set) { return set.Get(); }
        public void SetCallbacks(IActionKeyActions instance)
        {
            if (m_Wrapper.m_ActionKeyActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnUp;
                @Right.started -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnRight;
                @Down.started -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnLeft;
                @Pause.started -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ActionKeyActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ActionKeyActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ActionKeyActions @ActionKey => new ActionKeyActions(this);

    // TestKey
    private readonly InputActionMap m_TestKey;
    private ITestKeyActions m_TestKeyActionsCallbackInterface;
    private readonly InputAction m_TestKey_Space;
    public struct TestKeyActions
    {
        private @PlayerControls m_Wrapper;
        public TestKeyActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Space => m_Wrapper.m_TestKey_Space;
        public InputActionMap Get() { return m_Wrapper.m_TestKey; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestKeyActions set) { return set.Get(); }
        public void SetCallbacks(ITestKeyActions instance)
        {
            if (m_Wrapper.m_TestKeyActionsCallbackInterface != null)
            {
                @Space.started -= m_Wrapper.m_TestKeyActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_TestKeyActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_TestKeyActionsCallbackInterface.OnSpace;
            }
            m_Wrapper.m_TestKeyActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
            }
        }
    }
    public TestKeyActions @TestKey => new TestKeyActions(this);
    public interface IActionKeyActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface ITestKeyActions
    {
        void OnSpace(InputAction.CallbackContext context);
    }
}
