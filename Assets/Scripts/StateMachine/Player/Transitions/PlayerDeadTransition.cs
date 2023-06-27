using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerDeadTransition : Transition
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (_player.IsDead == true)
        {
            NeedTransit = true;
        }
    }
}