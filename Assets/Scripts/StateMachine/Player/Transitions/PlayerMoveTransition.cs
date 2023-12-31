using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMoveTransition : Transition
{
    private PlayerJumpState _playerJumpState;
    private bool _isFloor;
    private float _delay;
    private float _currentDelay;

    private void Awake()
    {
        _playerJumpState = GetComponent<PlayerJumpState>();
        _isFloor = false;
        _delay = 0.5f;
        _currentDelay = _delay;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Floor>(out Floor floor))
        {            
            _isFloor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Floor>(out Floor floor))
        {           
            _isFloor = false;
        }
    }

    private void Update()
    {
        if (_playerJumpState.IsJump && _isFloor && _currentDelay <= 0)
        {
            NeedTransit = true;
            _currentDelay = _delay;
        }
        else if (_playerJumpState.IsJump == false)
        {
            NeedTransit = true;
        }

        _currentDelay -= Time.deltaTime;
    }
}