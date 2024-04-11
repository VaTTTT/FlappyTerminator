using System.Collections;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    private void OnEnable()
    {
        _shootRoutine = StartCoroutine(nameof(Shoot));
        Debug.Log("Coroutine is started " + _shootRoutine);
    }

    private void OnDisable()
    {
        StopCoroutine(_shootRoutine);
    }
}