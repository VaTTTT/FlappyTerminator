using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _scoreCost;

    public event UnityAction<int> Died;

    public void Die()
    {
        Died?.Invoke(_scoreCost);
        gameObject.SetActive(false);
    }
}