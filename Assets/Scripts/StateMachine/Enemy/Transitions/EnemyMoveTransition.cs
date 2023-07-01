using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMoveTransition : Transition
{
    private Enemy _enemy;
    private Player _player;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();        
    }

    private void FixedUpdate() 
    {
        if ((_enemy.TargetPlayer == null && _enemy.TargetSandbags.gameObject.activeInHierarchy == false) 
            || _player.IsDead == true)
        {
            NeedTransit = true;            
        }
    } 

    public void Init(Player player)
    {
        _player = player;
    }
}