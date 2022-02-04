using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _spawnCount;
    [SerializeField] private List<Transform> _spawnPoints;

    private float _cooldown;
    private List<Barrier> _barrierPrefabs;
    private float _speed;
    private float _elapsedTime = 0f;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _cooldown)
        {
            _elapsedTime = 0f;

            List<Transform> spawnPoints = new List<Transform>();

            foreach (Transform spawnPoint in _spawnPoints)
            {
                spawnPoints.Add(spawnPoint);
            }

            for (int i = 0; i < _spawnCount; i++)
            {
                Transform chosenPoint = InstantiateBarrier(spawnPoints);
                
                spawnPoints.Remove(chosenPoint);
            }
        }
    }

    private Transform InstantiateBarrier(List<Transform> spawnPoints)
    {
        Transform chosenPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        Barrier barrierPrefab = _barrierPrefabs[Random.Range(0, _barrierPrefabs.Count)];
        
        Barrier barrier = Instantiate(barrierPrefab, chosenPoint.position,chosenPoint.rotation, _container);
        barrier.SetSpeed(_speed);

        return chosenPoint;
    }

    public void SetSettings(List<Barrier> barrierPrefabs, float speed, float spawnCooldown)
    {
        _barrierPrefabs = new List<Barrier>();
        _barrierPrefabs = barrierPrefabs;
        _speed = speed;
        _cooldown = spawnCooldown;
    }

    public void SetSpawnCount(int value)
    {
        _spawnCount = value;
    }
}
