using System;
using UnityEngine;

public class Enemy : Character
{
    public override event Action<Spawnable> Destroyed;
    public override event Action<Spawnable> Killed;

    public virtual void Initialize(Vector3 position)
    {
        transform.position = position;
        Health.Reset();
    }

    private void OnEnable()
    {
        Health.Died += KilledReleaseToSpawner;
    }

    private void KilledReleaseToSpawner()
    {
        Killed?.Invoke(this);
    }

    public void ReleaseToSpawner()
    {
        Destroyed?.Invoke(this);
    }
}
