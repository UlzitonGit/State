using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private PlayerInputHandler inputHandler;
    private bool canMove = true;
    
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();
        
        rb.gravityScale = 0;
    }
    
    public void Initialize(PlayerInputHandler handler)
    {
        inputHandler = handler;
    }
    
    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 movement = inputHandler.MoveInput * speed;
            rb.linearVelocity = movement;
        }
    }
    
    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
        if (!canMove)
            rb.linearVelocity = Vector2.zero;
    }
}