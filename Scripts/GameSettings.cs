using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private SOSettings[] _soSettings;
    [SerializeField] private float _sceneTime;
    [SerializeField] private BarrierSpawner _barrierSpawner;
    [SerializeField] private Portal _portal;
    [SerializeField] private Transform _portalContainer;

    private float _speed = 10f;
    private float _offsetIceSpeed = 0.2f;
    private float _spawnCooldown = 1f;
    private float _elapsedTime = 0;
    private SOSettings _chosenSettings;
    private bool _isFirstInit = true;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _sceneTime)
        {
            Init();

            _elapsedTime = 0f;
        }
    }

    private void Init()
    {
        List<SOSettings> Settings = new List<SOSettings>();

        foreach (SOSettings soSetting in _soSettings)
        {
            Settings.Add(soSetting);
        }

        Settings.Remove(_chosenSettings);

        SOSettings so = Settings[Random.Range(0, Settings.Count)];

        _chosenSettings = so;

        if (_isFirstInit == true)
        {
            so.InitMaterials(_offsetIceSpeed);
            _barrierSpawner.SetSettings(so.BarrierPrefabs, _speed, _spawnCooldown);
            
            _isFirstInit = false;
        }
        else
        {
            if (_speed < 34)
            {
                _speed += 2f;
                _offsetIceSpeed += 0.05f;
            }
            
            if (_spawnCooldown > 0.4f)
            {
                _spawnCooldown -= 0.05f;
            }

            Portal portal = Instantiate(_portal, _portalContainer);
            portal.SetSO(_chosenSettings, _barrierSpawner, _speed, _spawnCooldown, _offsetIceSpeed);
        }
    }
}
