using System.Collections;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToLive;

    private void Start()
    {
        StartCoroutine(DelayedDestroy(_timeToLive));
    }

    private void Update()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }

    //protected abstract void DestroyCollidingTarget(Collider2D target);

    private IEnumerator DelayedDestroy(float time)
    { 
        yield return new WaitForSeconds(time);
        
        Destroy(gameObject);
    }
}
