using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerJumpState : State
{
    [SerializeField] private float _upForce;
    [SerializeField] private float _rightForce;

    private PlayerDefenceTransition _defenceTransition;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isJump = false;
    public bool IsJump => _isJump;

    private void Awake()
    {
        _defenceTransition = GetComponent<PlayerDefenceTransition>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _isJump = false;
    }

    private void OnEnable()
    {
        if (_defenceTransition.Sandbags != null)
        {
            _rigidbody.AddForce(Vector2.up * _upForce, ForceMode2D.Force);
            _rigidbody.AddForce(Vector2.right * _rightForce, ForceMode2D.Force);
            _animator.Play("Jump");
            _isJump = true;
        }
        else
        {
            _isJump = false;
        }
    }
}