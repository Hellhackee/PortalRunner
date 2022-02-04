using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private BarrierSpawner _barrierSpawner;
    private float _speed;
    private SOSettings _so;
    private float _spawnCooldown;
    private float _offsetIceSpeed;

    private void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            foreach (Barrier barrier in _barrierSpawner.GetComponentsInChildren<Barrier>())
            {
                barrier.Die();
            }

            _so.InitMaterials(_offsetIceSpeed);
            _barrierSpawner.SetSettings(_so.BarrierPrefabs, _speed, _spawnCooldown);

            Destroy(gameObject, 3f);
        }
    }

    public void SetSO(SOSettings so, BarrierSpawner barrierSpawner, float speed, float spawnCooldown, float OffsetIceSpeed)
    {
        _so = so;
        _speed = speed;
        _barrierSpawner = barrierSpawner;
        _spawnCooldown = spawnCooldown;
        _offsetIceSpeed = OffsetIceSpeed;
    }
}
