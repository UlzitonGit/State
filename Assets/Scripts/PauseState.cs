using UnityEngine;

public class PauseState : GameState
{
    public PauseState(PlayerInputHandler input, StateMachine playerStateMachine, 
        PlayerMovement playerMovement, SpriteRenderer playerSprite, HUD hud) 
        : base(input, playerStateMachine, playerMovement, playerSprite, hud) { }
    
    public override void Enter()
    {
        hud.UpdateStateText("Paused");
        input.OnDisable();
        Time.timeScale = 0f;
    }
    
    public override void Update()
    {

    }
    
    public override void Exit()
    {
        
    }
}