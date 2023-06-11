using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplate;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private bool _inGame;
    private float _elepsedTime;

    private void Start()
    {
        _inGame = true;
        Initialize(_enemyTemplate);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetRandomObject(out GameObject enemy))
            {
                _elepsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                if (_inGame == true)
                    SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    public void StopSpawner() => _inGame = false;

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
