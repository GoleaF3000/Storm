using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAttack : SkillButton
{
    [SerializeField] private ParticleSystem _effectRocket;
    [SerializeField] private int _damage;
    [SerializeField] private float _coordinateX;
    [SerializeField] private float _coordinateY;
    [SerializeField] private float _coordinateZ;

    private ParticleSystem _effect;
    private Enemy[] _enemies;
    private Enemy[] _arrayToClear;
    private float _timeBeforeAttack;
    private float _delay;
    private bool _attackDone;

    protected new void Awake()
    {
        base.Awake();

        _effect = _effectRocket;
        _timeBeforeAttack = _effect.duration;
    }

    protected new void OnEnable()
    {
        base.OnEnable();

        _delay = _timeBeforeAttack;
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        _delay -= Time.deltaTime;

        if (_delay <= 0 && FindObjectOfType<Enemy>() == true && _attackDone == false)
        {
            foreach (var enemy in _enemies)
            {
                if (enemy != null)
                {
                    enemy.TakeDamage(_damage);
                }
            }
            
            _attackDone = true;
        }
    }

    protected new void OnDisable()
    {
        base.OnDisable();

        _enemies = _arrayToClear;
    }

    public override void StartAction()
    {    
        if (TryPayAction())
        {
            _attackDone = false;
            enabled = true;            
            StartEffect();
        }
    }

    private void StartEffect()
    {
        _effect = Instantiate(_effectRocket, new Vector3(_coordinateX + _player.transform.position.x, _coordinateY + _player.transform.position.y, _coordinateZ + _player.transform.position.z), Quaternion.identity);
        _effect.Play();
    }
}