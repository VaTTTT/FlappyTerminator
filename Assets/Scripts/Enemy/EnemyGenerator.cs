using System.Collections;
using UnityEngine;

public class EnemyGenerator : ObjectPool
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _delay;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new(_delay);
        Initialize(_template);

        StartCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        while (Time.timeScale > 0)
        {
            yield return _waitForSeconds;

            if (TryGetObject(out Enemy enemy))
            {
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                enemy.gameObject.SetActive(true);
                enemy.transform.position = spawnPoint;

                DisableEnemyAbroadScreen();
            }
        }
    }
}
