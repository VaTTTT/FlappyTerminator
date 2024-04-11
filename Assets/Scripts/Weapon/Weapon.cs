using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _bulletDelay;
    [SerializeField] private float _shotDelay;
    [SerializeField] private int _bulletsPerShot;
    [SerializeField] private GameObject _shootPoint;
    
    private WaitForSeconds _bulletRoutineDelay;
    private WaitForSeconds _shotRoutineDelay;
    private Animator _animator;
    protected Coroutine _shootRoutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _bulletRoutineDelay = new(_bulletDelay);
        _shotRoutineDelay = new(_shotDelay);
    }

    protected IEnumerator Shoot()
    {
        if (_shotDelay > 0)
        {
            yield return _shotRoutineDelay;
        }
        
        for (int i = 0; i < _bulletsPerShot; i++)
        {
            _animator.Play("Shoot");
            Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.transform.rotation);

            yield return _bulletRoutineDelay;
        }
    }
}
