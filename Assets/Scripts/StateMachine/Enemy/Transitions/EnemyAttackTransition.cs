using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAttackTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _enemy.SetTargetPlayer(player);
            NeedTransit = true;           
        }
        
        if (collision.TryGetComponent<Sandbags>(out Sandbags sandbags))
        {
            _enemy.SetTargetSandbags(sandbags);
            NeedTransit = true;           
        }  
    }
}