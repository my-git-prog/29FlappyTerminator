using UnityEngine;

public class SpawnerEnemyHard : Spawner<EnemyHard>
{
    [SerializeField] private SpawnerBullet _bulletSpawner;
    [SerializeField] private float _shootDeltaTime = 1.5f;
    [SerializeField] private Player _target;

    public void Spawn(Vector3 position)
    {
        var enemy = Pool.Get();
        enemy.Initialize(position, _shootDeltaTime, _bulletSpawner, _target);
    }
}
