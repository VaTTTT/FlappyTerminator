using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private Score _score;

    private Camera _camera;
    private List<Enemy> _pool = new();

    public void ResetPool()
    {
        foreach (var enemy in _pool)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    protected void Initialize(Enemy prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            spawned.Died += OnEnemyDied;

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out Enemy result)
    { 
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }

    protected void DisableEnemyAbroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var item in _pool)
        {
            if (item.transform.position.x < disablePoint.x)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    protected void OnEnemyDied(int scoreCost)
    {
        _score.IncreaseScore(scoreCost);
    }
}
