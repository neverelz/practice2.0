using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _zombiePrefab;

    [SerializeField] private float _spawnInterval;

    [SerializeField] private int _minX;
    [SerializeField] private int _maxX;
    [SerializeField] private int _minY;
    [SerializeField] private int _maxY;

    [SerializeField] private float _height;

    private float _currentSpawnTimer;

    Vector3 GenerateStartPosition()
    {
        var startPos = new Vector3(Random.Range(_minX, _maxX), _height, Random.Range(_minY, _maxY));
        return startPos;
    }
    void Update()
    {
        _currentSpawnTimer += Time.deltaTime;
        if (_currentSpawnTimer >= _spawnInterval)
        {
            var zombieInstance = Instantiate(_zombiePrefab);
            var newPosition = GenerateStartPosition();
            zombieInstance.transform.position = newPosition;
            _currentSpawnTimer = 0;
        }
    }
}
