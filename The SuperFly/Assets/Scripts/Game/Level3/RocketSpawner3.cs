using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner3 : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;

    [SerializeField] private float _spawnTime;
    private float _tempSpawnTime;

    private void Start()
    {
        _tempSpawnTime = _spawnTime;
    }

    private void Update()
    {
        if (ThirdLevelManager.isGameRunning)
        {
            if (_tempSpawnTime > 0) { _tempSpawnTime -= Time.deltaTime; }
            else
            {
                _tempSpawnTime = _spawnTime;
                SpawnRocket();
            }
        }
    }

    private void SpawnRocket()
    {
        Instantiate(_rocket, transform.position, Quaternion.identity);
    }
}
