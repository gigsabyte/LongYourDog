// GENERATED AUTOMATICALLY FROM 'Assets/Input/Mappings/InputControlMapping.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputControlMapping : IInputActionCollection
{
    private InputActionAsset asset;
    public InputControlMapping()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControlMapping"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""100962aa-7052-4acf-bc48-0133d25b4328"",
            ""actions"": [
                {
                    ""name"": ""PlayerMovement"",
                    ""type"": ""Value"",
                    ""id"": ""50997f3b-510d-47b9-b345-577f8d7b5315"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b47aaf74-706b-496b-bab2-5340803d0f28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""6eada02e-6c3b-499b-8a24-ce388a88df68"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""df7dc3e6-b8d4-4f6f-a1cb-8847e09daefa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovementMouse"",
                    ""type"": ""Button"",
                    ""id"": ""ae9a22ef-178f-4a51-886e-db1b246aedca"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9d5bf2f8-40c7-464a-a042-a3bd5c992c18"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""6b70ef3b-18ec-4955-8048-4c23b111ce36"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""a8be28fd-cee8-4c5d-8b4e-bacbfc3ff771"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ebc00104-8fd5-40ea-b8de-a193e9706c8d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e8cbd68c-3f20-4c14-8125-cf8a4c6cebf1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5bb604e3-dd60-4e61-8401-b7075e3f0519"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ee12d544-57b6-40ab-a38c-fedbb6b51008"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d7910cc8-90f3-462d-b261-151adf94f038"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""29c0394b-1b63-4640-955c-13c8c4a5a325"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""c03bdea0-84d2-4a29-989d-a1c540b8e52e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""54393594-8bfc-4687-abbf-ae273c9367fd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e0dab553-2b42-4708-bcce-6abbb36e1341"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""946c4c06-7a6b-443d-afac-8ec642104667"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c8efb295-602f-4bec-bc29-46b2f71ea5b1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""62ad970b-79e7-425c-a87d-011708d0f857"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5895e60-6bc1-48cd-88de-2bc91a55e042"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8e95376-83e4-4ba1-8853-bba610a44743"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89828dc8-3637-46a6-a806-e2a21c9a2e99"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3399ff20-68f0-41d4-872a-fb712373af0d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc9a1673-47f4-48c5-b19f-647a43538426"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ed7af9d-64e4-4c3b-964d-796a452e0410"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7799b7ea-4e9b-4430-b46d-737cab8dec3f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9067b3b9-ca85-45ed-bd97-327c980ddc98"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ea03ffa-b366-4dbb-bb8d-db5372925a72"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c33b571-5457-4221-a53e-97a0fc6327dd"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f09a9b2a-a39e-457c-877b-06f4e62be316"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f8258af-ccf1-4e3c-90b3-190c044fee6e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_PlayerMovement = m_Movement.FindAction("PlayerMovement", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Grab = m_Movement.FindAction("Grab", throwIfNotFound: true);
        m_Movement_CameraMovement = m_Movement.FindAction("CameraMovement", throwIfNotFound: true);
        m_Movement_CameraMovementMouse = m_Movement.FindAction("CameraMovementMouse", throwIfNotFound: true);
        m_Movement_Interact = m_Movement.FindAction("Interact", throwIfNotFound: true);
        m_Movement_Cancel = m_Movement.FindAction("Cancel", throwIfNotFound: true);
        m_Movement_OpenMenu = m_Movement.FindAction("OpenMenu", throwIfNotFound: true);
    }

    ~InputControlMapping()
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_PlayerMovement;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Grab;
    private readonly InputAction m_Movement_CameraMovement;
    private readonly InputAction m_Movement_CameraMovementMouse;
    private readonly InputAction m_Movement_Interact;
    private readonly InputAction m_Movement_Cancel;
    private readonly InputAction m_Movement_OpenMenu;
    public struct MovementActions
    {
        private InputControlMapping m_Wrapper;
        public MovementActions(InputControlMapping wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMovement => m_Wrapper.m_Movement_PlayerMovement;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Grab => m_Wrapper.m_Movement_Grab;
        public InputAction @CameraMovement => m_Wrapper.m_Movement_CameraMovement;
        public InputAction @CameraMovementMouse => m_Wrapper.m_Movement_CameraMovementMouse;
        public InputAction @Interact => m_Wrapper.m_Movement_Interact;
        public InputAction @Cancel => m_Wrapper.m_Movement_Cancel;
        public InputAction @OpenMenu => m_Wrapper.m_Movement_OpenMenu;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                PlayerMovement.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnPlayerMovement;
                PlayerMovement.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnPlayerMovement;
                PlayerMovement.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnPlayerMovement;
                Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                Grab.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnGrab;
                Grab.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnGrab;
                Grab.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnGrab;
                CameraMovement.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraMovement;
                CameraMovement.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraMovement;
                CameraMovement.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraMovement;
                CameraMovementMouse.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraMovementMouse;
                CameraMovementMouse.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraMovementMouse;
                CameraMovementMouse.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraMovementMouse;
                Interact.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnInteract;
                Interact.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnInteract;
                Interact.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnInteract;
                Cancel.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCancel;
                Cancel.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCancel;
                Cancel.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCancel;
                OpenMenu.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnOpenMenu;
                OpenMenu.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnOpenMenu;
                OpenMenu.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnOpenMenu;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                PlayerMovement.started += instance.OnPlayerMovement;
                PlayerMovement.performed += instance.OnPlayerMovement;
                PlayerMovement.canceled += instance.OnPlayerMovement;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Grab.started += instance.OnGrab;
                Grab.performed += instance.OnGrab;
                Grab.canceled += instance.OnGrab;
                CameraMovement.started += instance.OnCameraMovement;
                CameraMovement.performed += instance.OnCameraMovement;
                CameraMovement.canceled += instance.OnCameraMovement;
                CameraMovementMouse.started += instance.OnCameraMovementMouse;
                CameraMovementMouse.performed += instance.OnCameraMovementMouse;
                CameraMovementMouse.canceled += instance.OnCameraMovementMouse;
                Interact.started += instance.OnInteract;
                Interact.performed += instance.OnInteract;
                Interact.canceled += instance.OnInteract;
                Cancel.started += instance.OnCancel;
                Cancel.performed += instance.OnCancel;
                Cancel.canceled += instance.OnCancel;
                OpenMenu.started += instance.OnOpenMenu;
                OpenMenu.performed += instance.OnOpenMenu;
                OpenMenu.canceled += instance.OnOpenMenu;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnPlayerMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnCameraMovementMouse(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
    }
}
