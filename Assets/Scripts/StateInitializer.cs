using UnityEngine;

public static class StateInitializer
{
    public static StateMachine InitializePlayerStates(GameObject player, PlayerInputHandler input, PlayerMovement movement)
    {
        StateMachine machine = new StateMachine();
        
        machine.AddState(new ShootingState(player, input, movement));
        machine.AddState(new RedZoneState(player, input, movement));
        machine.AddState(new TransparentState(player, input, movement));
        
        
        machine.ChangeState<ShootingState>();
        
        return machine;
    }
    
    public static StateMachine InitializeGameStates(PlayerInputHandler input, StateMachine playerStateMachine,
        PlayerMovement playerMovement, SpriteRenderer playerSprite, HUD hud)
    {
        StateMachine machine = new StateMachine();
        
        machine.AddState(new GameplayState(input, playerStateMachine, playerMovement, playerSprite, hud));
        machine.AddState(new PauseState(input, playerStateMachine, playerMovement, playerSprite, hud));
        machine.AddState(new FinalState(input, playerStateMachine, playerMovement, playerSprite, hud));
        
        return machine;
    }
}