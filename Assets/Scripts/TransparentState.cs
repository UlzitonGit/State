using UnityEngine;

public class TransparentState : PlayerState
{
    private bool isTransparent = false;
    private Color originalColor;
    
    public TransparentState(GameObject player, PlayerInputHandler input, PlayerMovement movement) 
        : base(player, input, movement)
    {
        originalColor = spriteRenderer.color;
    }
    
    public override void Enter()
    {
        isTransparent = false;
    }
    
    public override void Update()
    {
        if (input.AttackPressed)
        {
            ToggleTransparency();
            input.ResetAttackPress();
        }
    }
    
    private void ToggleTransparency()
    {
        if (spriteRenderer == null) return;
        
        isTransparent = !isTransparent;
        Color newColor = originalColor;
        newColor.a = isTransparent ? 0.5f : 1f;
        spriteRenderer.color = newColor;
    }
    
    public override void Exit()
    {
        spriteRenderer.color = originalColor;
    }
}