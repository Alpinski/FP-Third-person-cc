// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerInput : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerControlls"",
            ""id"": ""95444078-25e3-44d2-9c43-b2d5ede84e49"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5922be8a-31b9-47ed-8e36-c6604c7877b1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ce964e5b-75ec-4030-b9bb-495ff04033ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e0c222c8-b60a-4e9a-b7dd-7ec40a36c8a6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""0d99aac4-a1aa-47ac-9dc3-fca1c8d257ab"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3b0ae4eb-6c82-4483-8991-98b42d9a0e17"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""91de91aa-ae54-4b12-bd0b-7f1dad9e2150"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7dde52de-da90-4d25-84f3-40f46bb6e06f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8b9a4190-bd52-4b0b-a59d-6180d907c404"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a009c394-9177-4012-a786-1a568398c5d1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControlls
        m_PlayerControlls = asset.FindActionMap("PlayerControlls", throwIfNotFound: true);
        m_PlayerControlls_Movement = m_PlayerControlls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControlls_Jump = m_PlayerControlls.FindAction("Jump", throwIfNotFound: true);
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

    // PlayerControlls
    private readonly InputActionMap m_PlayerControlls;
    private IPlayerControllsActions m_PlayerControllsActionsCallbackInterface;
    private readonly InputAction m_PlayerControlls_Movement;
    private readonly InputAction m_PlayerControlls_Jump;
    public struct PlayerControllsActions
    {
        private PlayerInput m_Wrapper;
        public PlayerControllsActions(PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControlls_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerControlls_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControlls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControllsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControllsActions instance)
        {
            if (m_Wrapper.m_PlayerControllsActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_PlayerControllsActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_PlayerControllsActionsCallbackInterface.OnMovement;
                Movement.canceled -= m_Wrapper.m_PlayerControllsActionsCallbackInterface.OnMovement;
                Jump.started -= m_Wrapper.m_PlayerControllsActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_PlayerControllsActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_PlayerControllsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerControllsActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerControllsActions @PlayerControlls => new PlayerControllsActions(this);
    public interface IPlayerControllsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
