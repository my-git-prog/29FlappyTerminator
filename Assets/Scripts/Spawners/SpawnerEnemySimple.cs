using UnityEngine;

public class SpawnerEnemySimple : Spawner<EnemySimple>
{
    [SerializeField] private SpawnerBullet _bulletSpawner;
    [SerializeField] private float _shootDeltaTime = 1.5f;

    public void Spawn(Vector3 position)
    {
        var enemy = Pool.Get();
        enemy.Initialize(position, _shootDeltaTime, _bulletSpawner);
    }
}
