using System.Collections;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                StartCoroutine(nameof(Shoot));
            }
        }
    }
}
