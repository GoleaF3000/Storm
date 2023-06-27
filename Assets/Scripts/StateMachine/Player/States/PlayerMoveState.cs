using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMoveState : State
{    
    private Player _player;
    private Animator _animator;
    private float _speed;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _speed = _player.SpeedPersonage;
    }

    private void OnEnable()
    {
        _animator.Play("Walk");
    }

    private void Update()
    {     
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}