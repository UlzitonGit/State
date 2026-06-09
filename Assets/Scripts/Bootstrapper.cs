using UnityEngine;
using System;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnPoint;
    
    private PlayerInputHandler inputHandler;
    private PlayerMovement playerMovement;
    private GameObject playerObject;
    private StateMachine gameStateMachine;
    private StateMachine playerStateMachine;
    private HUD hud;
    private int currentPlayerStateIndex = 0;
    private Type[] playerStateTypes;
    
    private void Awake()
    {
        InitializeGame();
    }
    
    private void InitializeGame()
    {
        
        playerObject = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        hud = playerObject.GetComponentInChildren<HUD>();
        inputHandler = playerObject.GetComponent<PlayerInputHandler>();
        playerMovement = playerObject.GetComponent<PlayerMovement>();
        
        playerMovement.Initialize(inputHandler);
        
        playerStateMachine = StateInitializer.InitializePlayerStates(
            playerObject, 
            inputHandler, 
            playerMovement
        );
        
        playerStateTypes = new Type[]
        {
            typeof(ShootingState),
            typeof(RedZoneState),
            typeof(TransparentState)
        };
        
        gameStateMachine = StateInitializer.InitializeGameStates(
            inputHandler,
            playerStateMachine,
            playerMovement,
            playerObject.GetComponent<SpriteRenderer>(),
            hud
        );
        
        gameStateMachine.ChangeState<GameplayState>();
    }
    
    private void Update()
    {
        HandleGameStateTransitions();
        
        if (inputHandler.SwitchStatePressed)
        {
            SwitchPlayerState();
            inputHandler.ResetSwitchStatePress();
        }
        
        gameStateMachine?.Update();
        playerStateMachine?.Update();
    }
    
    private void HandleGameStateTransitions()
    {
        Type currentStateType = gameStateMachine.GetCurrentState()?.GetType();
        
        if (currentStateType == typeof(GameplayState))
        {
            if (inputHandler.PausePressed)
            {
                gameStateMachine.ChangeState<PauseState>();
                inputHandler.ResetPausePress();
            }
            else if (inputHandler.ExitPressed)
            {
                gameStateMachine.ChangeState<FinalState>();
                inputHandler.ResetExitPress();
            }
        }
        else if (currentStateType == typeof(PauseState))
        {
            if (inputHandler.PausePressed)
            {
                gameStateMachine.ChangeState<GameplayState>();
                inputHandler.ResetPausePress();
            }
        }
    }
    
    private void SwitchPlayerState()
    {
        currentPlayerStateIndex = (currentPlayerStateIndex + 1) % playerStateTypes.Length;
        playerStateMachine.ChangeState(playerStateTypes[currentPlayerStateIndex]);
    }
}