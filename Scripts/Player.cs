using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _healthIcon;
    [SerializeField] private Transform _healthContainer;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private BarrierSpawner _barrierSpawner;

    public event UnityAction<int> CrystalTaken;

    private void Start()
    {
        _gameOverScreen.SetActive(false);

        for (int i = 0; i < _health; i++)
        {
            Instantiate(_healthIcon, _healthContainer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Barrier>(out Barrier barrier))
        {
            if (barrier.IsDead == false)
            {
                barrier.Die();

                if (barrier.IsEnemy)
                {
                    GetDamage();
                }
                else
                {
                    CrystalTaken?.Invoke(barrier.Award);
                }
            }
        }
    }

    private void GetDamage()
    {
        int health = _health - 1;

        if (health > 0)
        {
            _health = health;

            Transform[] healthIcon = _healthContainer.GetComponentsInChildren<Transform>();

            Destroy(healthIcon[healthIcon.Length - 1].gameObject);
        }
        else
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        foreach (Transform healthIcon in _healthContainer)
        {
            Destroy(healthIcon.gameObject);
        }

        _gameOverScreen.SetActive(true);
        _barrierSpawner.SetSpawnCount(0);
        
        foreach (Barrier barrier in _barrierSpawner.GetComponentsInChildren<Barrier>())
        {
            barrier.Die();
        }
    }
}
