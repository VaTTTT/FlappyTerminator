using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]

public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;
    private PlayerAnimator _playerAnimator;

    public event UnityAction Grounded;

    private void Start()
    {
        _player = GetComponent<Player>();
        _playerAnimator = _player.GetComponent<PlayerAnimator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            Grounded?.Invoke();
            _playerAnimator.PlayRunAnimation();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out _))
        { 
            _player.Die();
        }
    }
}