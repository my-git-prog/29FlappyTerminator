using UnityEngine;

public class EnemyHard : EnemySimple
{
    [SerializeField] EnemyHardMover _mover;
    public void Initialize(Vector3 position, float shootDeltaTime, SpawnerBullet _bulletSpawner, Player target)
    {
        Initialize(position, shootDeltaTime, _bulletSpawner);
        _mover.Initialize(target);
    }
}
