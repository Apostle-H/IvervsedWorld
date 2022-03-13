// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Simple"",
            ""id"": ""f3a2aa27-8505-4ae8-91c9-66efeff675df"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1205c12a-fe40-4d16-b0d0-15949115a6aa"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ddd00e67-06e1-466d-907e-602d13662b1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""4ba28246-5a33-4e10-a68a-88e6642c3bb1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a83381a4-ab16-45a1-9ec8-bb37109d249b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""80d2dfb8-b195-451a-8348-82a77611c354"",
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
                    ""id"": ""2fe91ca1-d9f3-4807-b341-e03b49a5f0f8"",
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
        // Simple
        m_Simple = asset.FindActionMap("Simple", throwIfNotFound: true);
        m_Simple_Movement = m_Simple.FindAction("Movement", throwIfNotFound: true);
        m_Simple_Jump = m_Simple.FindAction("Jump", throwIfNotFound: true);
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

    // Simple
    private readonly InputActionMap m_Simple;
    private ISimpleActions m_SimpleActionsCallbackInterface;
    private readonly InputAction m_Simple_Movement;
    private readonly InputAction m_Simple_Jump;
    public struct SimpleActions
    {
        private @PlayerInputActions m_Wrapper;
        public SimpleActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Simple_Movement;
        public InputAction @Jump => m_Wrapper.m_Simple_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Simple; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SimpleActions set) { return set.Get(); }
        public void SetCallbacks(ISimpleActions instance)
        {
            if (m_Wrapper.m_SimpleActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_SimpleActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_SimpleActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_SimpleActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_SimpleActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_SimpleActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_SimpleActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_SimpleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public SimpleActions @Simple => new SimpleActions(this);
    public interface ISimpleActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
