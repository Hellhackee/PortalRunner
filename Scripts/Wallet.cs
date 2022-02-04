using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _crystalLabel;

    private int _money = 0;

    private void OnEnable()
    {
        _player.CrystalTaken += OnEnemyDied;
    }

    private void OnDisable()
    {
        _player.CrystalTaken += OnEnemyDied;
    }

    private void OnEnemyDied(int value)
    {
        _money += value;
        _crystalLabel.text = _money.ToString();
    }
}
