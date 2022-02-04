using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private int _award;
    [SerializeField] private GameObject _crystalFull;
    [SerializeField] private GameObject _crystalParts;
    [SerializeField] private bool _isEnemy;
    [SerializeField] private bool _dontRotate = false;

    private float _speed;
    private bool _isDead = false;

    public bool IsEnemy => _isEnemy;
    public bool IsDead => _isDead;

    public int Award => _award;


    private void Awake()
    {
        if (_dontRotate == false)
        {
            float rotation = Random.Range(0, 360);

            _crystalFull.transform.localRotation = Quaternion.Euler(0, rotation, 0);
            _crystalParts.transform.localRotation = Quaternion.Euler(0, rotation, 0);
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(1,0,0) * _speed * Time.deltaTime);
    }

    public void Die()
    {
        _crystalFull.SetActive(false);
        _crystalParts.SetActive(true);
        _isDead = true;

        gameObject.transform.SetParent(Camera.main.transform);

        Destroy(gameObject, 6f);
    }

    public void SetSpeed(float value)
    {
        _speed = value;
    }
}
