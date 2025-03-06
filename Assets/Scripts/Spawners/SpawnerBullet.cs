using UnityEngine;

public class SpawnerBullet : Spawner<Bullet>
{
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private float _minimumShootSoundPitch = 0.8f;
    [SerializeField] private float _maximumShootSoundPitch = 1.2f;

    public void Shoot(Transform shootPoint, float speed, int damage)
    {
        var bullet = Pool.Get();
        bullet.Initialize(shootPoint, speed, damage);
        _shootSound.pitch = Random.Range(_minimumShootSoundPitch, _maximumShootSoundPitch);
        _shootSound.Play();
    }
}
