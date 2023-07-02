using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _countEnemy;
    [SerializeField] private Vector2 _minOfset;
    [SerializeField] private Vector2 _maxOfset;    
    [SerializeField] private Player _player;
    [SerializeField] private PlayerWallet _wallet;

    private float _multiplicity = 100;
    private System.Random _random = new System.Random();

    public void Spawn()
    {
        for (int i = 0; i < _countEnemy; i++)
        {
            float positionX = transform.position.x + ((Convert.ToSingle(_random.Next
                (Convert.ToInt32(_minOfset.x * _multiplicity),
                Convert.ToInt32(_maxOfset.x * _multiplicity)))) / _multiplicity);
            float positionY = transform.position.y + ((Convert.ToSingle(_random.Next
                (Convert.ToInt32(_minOfset.y * _multiplicity),
                Convert.ToInt32(_maxOfset.y * _multiplicity)))) / _multiplicity);
            Vector3 position = new Vector3(positionX, positionY, 0);

            var spawnedEnemy = Instantiate(_enemy, position, Quaternion.identity);
            spawnedEnemy.Init(_player, _wallet);
        }
    }
}