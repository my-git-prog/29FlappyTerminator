using UnityEngine;

public class SpawnerAsteroid : Spawner<Asteroid>
{
    [SerializeField] private float _minimumRotationSpeed = -100f;
    [SerializeField] private float _maximumRotationSpeed = 100f;

    public void Spawn(Vector3 position)
    {
        var enemy = Pool.Get();
        enemy.Initialize(position, GetRandomRotationSpeed());
    }

    private float GetRandomRotationSpeed()
    {
        return Random.Range(_minimumRotationSpeed, _maximumRotationSpeed);
    }
}
