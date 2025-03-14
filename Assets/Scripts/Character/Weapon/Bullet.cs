using System;
using System.Collections;
using UnityEngine;

public class Bullet : Spawnable
{
    [SerializeField] private float _lifeTime = 5f;
    
    private float _speed;
    private int _damage;
    private WaitForSeconds _waitLifeTime;
    private bool _isEnemyBullet;

    public override event Action<Spawnable> Destroyed;
    public override event Action<Spawnable> Killed;

    private void Awake()
    {
        _waitLifeTime = new WaitForSeconds(_lifeTime);
    }

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
    }

    public void Initialize (Transform shootPoint, float speed, int damage, bool IsEnemyBullet)
    {
        transform.position = shootPoint.position;
        transform.rotation = shootPoint.rotation;
        _speed = speed;
        _damage = damage;
        _isEnemyBullet = IsEnemyBullet;
        StartCoroutine(DelaydDestroy());
    }

    private IEnumerator DelaydDestroy()
    {
        yield return _waitLifeTime;

        Destroyed?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            if (_isEnemyBullet)
                if (damagable is Enemy)
                    return;

            damagable.TakeDamage(_damage);
            Killed?.Invoke(this);
        }
    }
}
