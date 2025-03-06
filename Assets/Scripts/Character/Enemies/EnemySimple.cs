using UnityEngine;

public class EnemySimple : Enemy
{
    [SerializeField] private Gun _gun;

    public void Initialize(Vector3 position, float shootDeltaTime, SpawnerBullet _bulletSpawner)
    {
        Initialize(position);
        _gun.SetBulletSpawner(_bulletSpawner);
        _gun.StartShooting(shootDeltaTime);
    }
}
