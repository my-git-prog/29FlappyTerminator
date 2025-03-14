using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : Spawnable
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 50;
    [SerializeField] private int _killingScore = 10;
    [SerializeField] private AudioSource _killingSound;
    [SerializeField] private float _minimumKillingSoundPitch = 0.8f;
    [SerializeField] private float _maximumKillingSoundPitch = 1.2f;
    [SerializeField] private Effect _killingEffect;

    private ObjectPool<T> _pool;
    private List<Spawnable> _activeObjects = new List<Spawnable>();

    public event Action<int> ObjectKilled;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => CreateItem(),
            actionOnGet: (obj) => ActivateItem(obj),
            actionOnRelease: (obj) => DeactivateItem(obj),
            actionOnDestroy: (obj) => DestroyItem(obj),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
            );
    }

    private T CreateItem()
    {
        return Instantiate(_prefab);
    }

    private void ReleaseItem(Spawnable obj)
    {
        obj.Destroyed -= ReleaseItem;
        obj.Killed -= KillItem;
        _pool.Release(obj as T);
    }

    private void KillItem(Spawnable obj)
    {
        ObjectKilled?.Invoke(_killingScore);
        _killingSound.pitch = UnityEngine.Random.Range(_minimumKillingSoundPitch, _maximumKillingSoundPitch);
        _killingSound.Play();
        _killingEffect.Show(obj.transform.position);
        ReleaseItem(obj);
    }

    private void ActivateItem(Spawnable obj)
    {
        obj.Destroyed += ReleaseItem;
        obj.Killed += KillItem;
        obj.gameObject.SetActive(true);
        _activeObjects.Add(obj);
    }

    private void DeactivateItem(T obj)
    {
        obj.gameObject.SetActive(false);
        _activeObjects.Remove(obj);
    }

    private void DestroyItem(T obj)
    {
        Destroy(obj.gameObject);
    }

    protected T GetItem()
    {
        return _pool.Get();
    }

    public void Reset()
    {
        List<Spawnable> objectsToRelease = new List<Spawnable>();

        foreach (var obj in _activeObjects)
        {
            objectsToRelease.Add(obj);
        }

        foreach (var obj in objectsToRelease)
        {
            ReleaseItem(obj);
        }
    }
}