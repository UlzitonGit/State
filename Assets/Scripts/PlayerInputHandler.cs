using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls controls;
    
    public Vector2 MoveInput { get; private set; }
    public bool AttackPressed { get; private set; }
    public bool SwitchStatePressed { get; private set; }
    public bool PausePressed { get; private set; }
    public bool ExitPressed { get; private set; }
    
    private void Awake()
    {
        controls = new PlayerControls();
    }

    public void OnEnable()
    {
        controls.Enable();
        
        controls.Gameplay.Move.performed += OnMove;
        controls.Gameplay.Move.canceled += OnMove;
        controls.Gameplay.Attack.performed += OnAttack;
        controls.Gameplay.SwitchState.performed += OnSwitchState;
        controls.Gameplay.Pause.performed += OnPause;
        controls.Gameplay.Exit.performed += OnExit;
    }

    public void OnDisable()
    {
        controls.Disable();
        
        controls.Gameplay.Move.performed -= OnMove;
        controls.Gameplay.Move.canceled -= OnMove;
        controls.Gameplay.Attack.performed -= OnAttack;
        controls.Gameplay.SwitchState.performed -= OnSwitchState;
        controls.Gameplay.Pause.performed -= OnPause;
        controls.Gameplay.Exit.performed -= OnExit;
    }
    
    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
    
    private void OnAttack(InputAction.CallbackContext context)
    {
        AttackPressed = context.performed;
    }
    
    private void OnSwitchState(InputAction.CallbackContext context)
    {
        SwitchStatePressed = context.performed;
    }
    
    private void OnPause(InputAction.CallbackContext context)
    {
        PausePressed = context.performed;
    }
    
    private void OnExit(InputAction.CallbackContext context)
    {
        ExitPressed = context.performed;
    }
    
    public void ResetAttackPress()
    {
        AttackPressed = false;
    }
    
    public void ResetSwitchStatePress()
    {
        SwitchStatePressed = false;
    }
    
    public void ResetPausePress()
    {
        PausePressed = false;
    }
    
    public void ResetExitPress()
    {
        ExitPressed = false;
    }
}