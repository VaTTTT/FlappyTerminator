using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void DestroyCollidingTarget(Collider2D target)
    {
        if (target.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
        }
    }
}