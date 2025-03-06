using System;
using System.Collections;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    const int StartLevel = 1;

    [SerializeField] private SpawnerBullet _spawnerBullet;
    [SerializeField] private SpawnerAsteroid _spawnerAsteroid;
    [SerializeField] private SpawnerEnemySimple _spawnerEnemySimple;
    [SerializeField] private SpawnerEnemyHard _spawnerEnemyHard;
    [SerializeField] private bool _isSpawning = true;
    [SerializeField] private float _maximumSpawnDeltaTime = 5f;
    [SerializeField] private float _minimumSpawnDeltaTime = 2f;
    [SerializeField] private int _maximumLevel = 30;
    [SerializeField] private float _startProbabilityAsteroid = 1f;
    [SerializeField] private float _probabilityAsteroidMultiplier = 0f;
    [SerializeField] private float _startProbabilityEnemySimple = 1f;
    [SerializeField] private float _probabilityEnemySimpleMultiplier = 1f;
    [SerializeField] private float _startProbabilityEnemyHard = -10f;
    [SerializeField] private float _probabilityEnemyHardMultiplier = 2f;
    [SerializeField] private float _minimumEnemyYPosition = -8f;
    [SerializeField] private float _maximumEnemyYPosition = 8f;

    private Coroutine _coroutine;
    private float _spawnDeltaTime;
    private float _probabilityAsteroid;
    private float _probabilityEnemySimple;
    private float _probabilityEnemyHard;
    private float _probabilityFull;

    public event Action<int> ObjectKilled;

    private void Awake()
    {
        _spawnDeltaTime = _maximumSpawnDeltaTime;
        _probabilityAsteroid = _startProbabilityAsteroid;
        _probabilityEnemySimple = _startProbabilityEnemySimple;
        _probabilityEnemyHard = _startProbabilityEnemyHard;
        CalcSpawnParameters(StartLevel);
        Reset();
    }
    private void OnEnable()
    {
        _spawnerAsteroid.ObjectKilled += AddScore;
        _spawnerEnemySimple.ObjectKilled += AddScore;
        _spawnerEnemyHard.ObjectKilled += AddScore;
    }

    private void OnDisable()
    {
        _spawnerAsteroid.ObjectKilled -= AddScore;
        _spawnerEnemySimple.ObjectKilled -= AddScore;
        _spawnerEnemyHard.ObjectKilled -= AddScore;
    }

    private void AddScore(int score)
    {
        ObjectKilled?.Invoke(score);
    }

    public void Reset()
    {
        _spawnerBullet.Reset();
        _spawnerAsteroid.Reset();
        _spawnerEnemySimple.Reset();
        _spawnerEnemyHard.Reset();
        RestartSpawnCoroutine();
    }

    private void RestartSpawnCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SpawnEnemies());
    }

    public void SetLevel(int level)
    {
        CalcSpawnParameters(level);
        RestartSpawnCoroutine();
    }

    private void CalcSpawnParameters(int level)
    {
        _spawnDeltaTime = Mathf.Lerp(_maximumSpawnDeltaTime, _minimumSpawnDeltaTime, ((float)level) / _maximumLevel);
        _probabilityAsteroid = Mathf.Clamp(_startProbabilityAsteroid + _probabilityAsteroidMultiplier * level, 0f, float.MaxValue);
        _probabilityEnemySimple = Mathf.Clamp(_startProbabilityEnemySimple + _probabilityEnemySimpleMultiplier * level, 0f, float.MaxValue);
        _probabilityEnemyHard = Mathf.Clamp(_startProbabilityEnemyHard + _probabilityEnemyHardMultiplier * level, 0f, float.MaxValue);
        _probabilityFull = _probabilityAsteroid + _probabilityEnemySimple + _probabilityEnemyHard;
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_spawnDeltaTime);

        while (_isSpawning)
        {
            yield return wait;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float probability = UnityEngine.Random.Range(0f, _probabilityFull);
        Vector3 position = GetRandomSpawnPoint();

        if (probability - _probabilityEnemyHard < 0)
        {
            _spawnerEnemyHard.Spawn(position);
            return;
        }

        probability -= _probabilityEnemyHard;

        if (probability - _probabilityEnemySimple < 0)
        {
            _spawnerEnemySimple.Spawn(position);
        }
        else
        {
            _spawnerAsteroid.Spawn(position);
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(transform.position.x,
            transform.position.y + UnityEngine.Random.Range(_minimumEnemyYPosition, _maximumEnemyYPosition),
            transform.position.z);
    }
}
