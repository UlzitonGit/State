using UnityEngine;

public abstract class GameState : IState
{
    protected PlayerInputHandler input;
    protected StateMachine playerStateMachine;
    protected PlayerMovement playerMovement;
    protected SpriteRenderer playerSprite;
    protected HUD hud;
    
    protected GameState(PlayerInputHandler input, StateMachine playerStateMachine, 
        PlayerMovement playerMovement, SpriteRenderer playerSprite, HUD hud)
    {
        this.input = input;
        this.playerStateMachine = playerStateMachine;
        this.playerMovement = playerMovement;
        this.playerSprite = playerSprite;
        this.hud = hud;
    }
    
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}