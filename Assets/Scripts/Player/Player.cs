using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    private PlayerMover _mover;

    public event UnityAction GameOver;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    public void ResetPlayer()
    {
        _mover.ResetPlayerCoordinates();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
