using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReseter : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Player _player;
    [SerializeField] private List<EnemyGenerator> _enemyGenerators;

    public void ResetAllValues()
    { 
        _score.ResetScore();
        _player.ResetPlayer();

        foreach(EnemyGenerator generator in _enemyGenerators)
        {
            generator.ResetPool();
        }
    }
}
