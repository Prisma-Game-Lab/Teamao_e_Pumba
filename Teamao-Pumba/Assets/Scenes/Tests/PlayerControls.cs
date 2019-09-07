// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/Tests/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""CubeTeste"",
            ""id"": ""a2877058-de76-45df-8674-e80c262fa58f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""35e0d0a9-1f44-4d4d-b29b-b6c823a4096a"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f97dcfbe-1219-45c2-87d2-299c2b3d6015"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CubeTeste
        m_CubeTeste = asset.GetActionMap("CubeTeste");
        m_CubeTeste_Move = m_CubeTeste.GetAction("Move");
    }

    ~PlayerControls()
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

    // CubeTeste
    private readonly InputActionMap m_CubeTeste;
    private ICubeTesteActions m_CubeTesteActionsCallbackInterface;
    private readonly InputAction m_CubeTeste_Move;
    public struct CubeTesteActions
    {
        private PlayerControls m_Wrapper;
        public CubeTesteActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CubeTeste_Move;
        public InputActionMap Get() { return m_Wrapper.m_CubeTeste; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CubeTesteActions set) { return set.Get(); }
        public void SetCallbacks(ICubeTesteActions instance)
        {
            if (m_Wrapper.m_CubeTesteActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_CubeTesteActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_CubeTesteActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_CubeTesteActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_CubeTesteActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
            }
        }
    }
    public CubeTesteActions @CubeTeste => new CubeTesteActions(this);
    public interface ICubeTesteActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
