using UnityEngine;

public abstract class PlayerState : IState
{
    protected GameObject player;
    protected PlayerInputHandler input;
    protected PlayerMovement movement;
    protected SpriteRenderer spriteRenderer;
    
    protected PlayerState(GameObject player, PlayerInputHandler input, PlayerMovement movement)
    {
        this.player = player;
        this.input = input;
        this.movement = movement;
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }
    
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}