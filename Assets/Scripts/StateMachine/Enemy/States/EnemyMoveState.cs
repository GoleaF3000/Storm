using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMoveState : State
{
    private Enemy _enemy;
    private Player _player;
    private float _speed;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();        
        _speed = _enemy.SpeedPersonage;
    }

    private void Update()
    {
        if (_player.IsDead == false)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
    }

    public void Init(Player player)
    {
        _player = player;
    }
}