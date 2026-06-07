using UnityEngine;

public class ShootingState : PlayerState
{
    private GameObject bulletPrefab;
    private float bulletSpeed = 10f;
    
    public ShootingState(GameObject player, PlayerInputHandler input, PlayerMovement movement) 
        : base(player, input, movement)
    {
        bulletPrefab = Resources.Load<GameObject>("Bullet");
    }
    
    public override void Enter()
    {
    }
    
    public override void Update()
    {
        if (input.AttackPressed)
        {
            Shoot();
            input.ResetAttackPress();
        }
    }
    
    private void Shoot()
    {
        if (bulletPrefab == null) return;
        
        GameObject bullet = Object.Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        if (rb != null)
        {
            rb.linearVelocity = Vector2.right * bulletSpeed;
        }
        
        Object.Destroy(bullet, 2f);
    }
    
    public override void Exit()
    {
    }
}