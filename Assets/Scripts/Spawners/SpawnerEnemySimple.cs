using UnityEngine;

public class SpawnerEnemySimple : Spawner<EnemySimple>
{
    [SerializeField] private SpawnerBullet _bulletSpawner;
    [SerializeField] private float _shootDeltaTime = 1.5f;

    public void Spawn(Vector3 position)
    {
        GetItem().Initialize(position, _shootDeltaTime, _bulletSpawner);
    }
}
