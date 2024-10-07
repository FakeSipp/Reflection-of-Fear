using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name References")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    [SerializeField] private string move = "Movement";
    [SerializeField] private string run = "Run";
    [SerializeField] private string look = "Look";
    [SerializeField] private string interact = "Interaction";
    [SerializeField] private string flashlight = "Flashlight";

    private InputAction moveAction;
    private InputAction runAction;
    private InputAction lookAction;
    private InputAction interactAction;
    private InputAction flashlightAction;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool RunInput { get; private set; }
    public bool InteractInput {  get; set; }
    public bool FlashlightInput {  get; set; }

    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        runAction = playerControls.FindActionMap(actionMapName).FindAction(run);
        lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);
        interactAction = playerControls.FindActionMap(actionMapName).FindAction(interact);
        flashlightAction = playerControls.FindActionMap(actionMapName).FindAction(flashlight);
        RegisterInputAction();
    }

    private void RegisterInputAction()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = Vector2.zero;

        runAction.performed += context => RunInput = true;
        runAction.canceled += context => RunInput = false;

        interactAction.performed += context => InteractInput = true;
        interactAction.canceled += context => InteractInput = false;

        flashlightAction.performed += context => FlashlightInput = true;
        flashlightAction.canceled += context => FlashlightInput = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        runAction.Enable();
        lookAction.Enable();
        interactAction.Enable();
        flashlightAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        runAction.Disable();
        lookAction.Disable();
        interactAction.Disable();
        flashlightAction.Disable();
    }
}
