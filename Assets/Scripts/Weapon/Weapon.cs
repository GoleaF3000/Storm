using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private RateOfFireButton _rateOfFireButton;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _damage;
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _delay;

    private Animator _animator;
    private Transform _weaponPosition;
    private float _originalDelay;

    public float Delay => _delay;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _weaponPosition = GetComponent<Transform>();
        _originalDelay = _delay;
    }

    private void OnEnable()
    {
        _rateOfFireButton.OnSignalTemporary += DecreaseDelay;
        _rateOfFireButton.OffSignalTemporary += ReturnDelay;
    }

    private void OnDisable()
    {
        _rateOfFireButton.OnSignalTemporary -= DecreaseDelay;
        _rateOfFireButton.OffSignalTemporary -= ReturnDelay;
    }

    public void Shooting(ref float delay)
    {
        if (delay <= 0)
        {
            Instantiate(_bullet, _weaponPosition.position, Quaternion.identity);
            _animator.Play("Fire");
            delay = _delay;
        }

        delay -= Time.deltaTime;
    }

    public void DecreaseDelay()
    {
        _delay = _rateOfFireButton.Delay;
    }

    private void ReturnDelay()
    {
        _delay = _originalDelay;
    }
}