using System.Collections;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(nameof(Shoot));
        }
    }
}
