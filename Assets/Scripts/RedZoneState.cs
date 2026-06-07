using UnityEngine;

public class RedZoneState : PlayerState
{
    private GameObject redZoneObject;
    private bool isActive = false;
    
    public RedZoneState(GameObject player, PlayerInputHandler input, PlayerMovement movement) 
        : base(player, input, movement)
    {
        CreateRedZone();
    }
    
    private void CreateRedZone()
    {
        redZoneObject = Resources.Load<GameObject>("RedZoneState");
        
        redZoneObject.SetActive(false);
    }
    
    public override void Enter()
    {
        isActive = false;
    }
    
    public override void Update()
    {
        if (input.AttackPressed)
        {
            ToggleRedZone();
            input.ResetAttackPress();
        }
    }
    
    private void ToggleRedZone()
    {
        isActive = !isActive;
        redZoneObject.SetActive(isActive);
    }
    
    public override void Exit()
    {
        redZoneObject.SetActive(false);
    }
}