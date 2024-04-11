using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void DestroyCollidingTarget(Collider2D target)
    {
        if (target.TryGetComponent(out Player player))
        {
            player.Die();
        }
    }
}
