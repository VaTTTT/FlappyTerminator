using System.Collections;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    private void OnEnable()
    {
        _shootRoutine = StartCoroutine(nameof(Shoot));
    }

    private void OnDisable()
    {
        StopCoroutine(_shootRoutine);
    }
}