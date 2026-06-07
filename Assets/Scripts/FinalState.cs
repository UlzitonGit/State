using UnityEngine;

public class FinalState : GameState
{
    public FinalState(PlayerInputHandler input, StateMachine playerStateMachine, 
        PlayerMovement playerMovement, SpriteRenderer playerSprite, HUD hud) 
        : base(input, playerStateMachine, playerMovement, playerSprite, hud) { }
    
    public override void Enter()
    {
        hud.UpdateStateText("Final");
        input.OnDisable();
        Time.timeScale = 1f;
        
        if (playerSprite != null)
            playerSprite.color = Color.green;
        
        playerMovement.SetCanMove(false);
        
    }
    
    public override void Update()
    {
    }
    
    public override void Exit()
    {
    }
}