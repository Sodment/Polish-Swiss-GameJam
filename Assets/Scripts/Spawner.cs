using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float _baseWaveValue = 50;
    [SerializeField] private float _waveInterval = 10f;
    [SerializeField] private float _firstWaveDelay = 30f;

    [Space]
    [SerializeField] private GameObject[] _enemyPrefabs;

    private float _enemyInverseValueSum;
    private float _waveTimer;
    private bool _isWaveActive;
    private int _waveNumber;

    public List<Enemy> AliveEnemies { get; private set; } = new List<Enemy>();

    private void Start()
    {
        _waveTimer = _firstWaveDelay;

        CalculateConstants();
    }

    private void Update()
    {
        CheckEnemiesHealth();
        HandleWaves();
    }

    private void CheckEnemiesHealth() 
    {
        var deadEnemies = new List<Enemy>();

        foreach (var enemy in AliveEnemies)
        {
            if (enemy.IsDead)
            {
                enemy.Die();
                deadEnemies.Add(enemy);
            }
        }

        foreach (var deadEnemy in deadEnemies)
            AliveEnemies.Remove(deadEnemy);
    }

    private void HandleWaves()
    {
        if (_isWaveActive && AliveEnemies.Count == 0)
        {
            _isWaveActive = false;
            _waveTimer = _waveInterval;
        }

        if (!_isWaveActive)
        {
            _waveTimer -= Time.deltaTime;
            if (_waveTimer <= 0)
                StartWave(Generate((_waveNumber + 1) * _baseWaveValue));
        }
    }

    private void CalculateConstants()
    {
        _enemyInverseValueSum = CalculateEnemyInverseSum();
    }

    private float CalculateEnemyInverseSum()
    {
        float inverseSum = 0;

        foreach (var enemyPrefab in _enemyPrefabs)
        {
            var enemy = enemyPrefab.GetComponent<Enemy>();
            inverseSum += 1 / enemy.Value;
        }

        return inverseSum;
    }

    public List<Enemy> Generate(float waveValue)
    {
        var enemies = new List<Enemy>();

        foreach (var enemyPrefab in _enemyPrefabs)
        {
            var enemy = enemyPrefab.GetComponent<Enemy>();

            var weight = (1 / enemy.Value) / _enemyInverseValueSum;
            var numberOfEnemies = (weight * waveValue) / enemy.Value;

            for (int i = 0; i < numberOfEnemies; i++)
                enemies.Add(enemy);
        }

        return RandomizeList(enemies);
    }

    public List<Enemy> RandomizeList(List<Enemy> list)
    {
        List<Enemy> randomizedList = new List<Enemy>();

        List<int> freeIndices = Enumerable.Range(0, list.Count).ToList();

        for (int i = 0; i < list.Count; i++)
        {
            int indicesIndex = Random.Range(0, freeIndices.Count);
            int newIndex = freeIndices[indicesIndex];

            randomizedList.Add(list[newIndex]);
            freeIndices.RemoveAt(indicesIndex);
        }

        return randomizedList.ToList();
    }

    public void StartWave(List<Enemy> enemies)
    {
        _isWaveActive = true;

        for (int i = 0; i < enemies.Count; i++)
        {
            StartCoroutine(SpawnEnemyDelayed(enemies[i], i * _spawnInterval));
        }
    }

    private IEnumerator SpawnEnemyDelayed(Enemy enemy, float delay)
    {
        var t = 0f;
        while (t < delay)
        {
            yield return null;
            t += Time.deltaTime;
        }

        SpawnEnemy(enemy);
    }

    private void SpawnEnemy(Enemy enemy)
    {
        var instancedEnemy = Instantiate(enemy.gameObject, transform);
        instancedEnemy.transform.position = _spawnPosition.transform.position;
        AliveEnemies.Add(instancedEnemy.GetComponent<Enemy>());
    }
}
