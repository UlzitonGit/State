using UnityEngine;

public class GameplayState : GameState
{
    public GameplayState(PlayerInputHandler input, StateMachine playerStateMachine, 
        PlayerMovement playerMovement, SpriteRenderer playerSprite, HUD hud) 
        : base(input, playerStateMachine, playerMovement, playerSprite, hud) { }
    
    public override void Enter()
    {
        hud.UpdateStateText("Gameplay");
        input.OnEnable();
        Time.timeScale = 1f;
    }
    
    public override void Update()
    {
        if (input.PausePressed)
        {
            input.ResetPausePress();
        }
        
        if (input.ExitPressed)
        {
            input.ResetExitPress();
        }
    }
    
    public override void Exit()
    {
      
    }
}