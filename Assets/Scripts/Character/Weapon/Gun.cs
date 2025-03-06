using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private SpawnerBullet _spawnerBullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private int _bulletDamage = 1;

    private bool _isShooting = true;

    public void Shoot()
    {
        _spawnerBullet.Shoot(_shootPoint, _bulletSpeed, _bulletDamage);
    }

    public void SetBulletSpawner(SpawnerBullet bulletSpawner)
    {
        _spawnerBullet = bulletSpawner;
    }

    public void StartShooting(float shootDeltaTime)
    {
        _isShooting = true;
        StartCoroutine(PeriodicalShooting(shootDeltaTime));
    }

    public void StopShooting()
    {
        _isShooting = false;
    }

    private IEnumerator PeriodicalShooting(float shootDeltaTime)
    {
        var wait = new WaitForSeconds(shootDeltaTime);

        while (_isShooting)
        {
            Shoot();
            yield return wait;
        }
    }
}
