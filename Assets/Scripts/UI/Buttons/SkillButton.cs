using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class SkillButton : MonoBehaviour
{
    [SerializeField] protected Player _player;
    [SerializeField] private bool _isPaid;
    [SerializeField] private int _price;
    [SerializeField] private bool _isTemporary;
    [SerializeField] private float _timeAction;
    [SerializeField] private bool _isBlocked;
    [SerializeField] private float _timeBlocked;
    [SerializeField] private Timer _timer;

    public UnityAction OnSignalTemporary;
    public UnityAction OffSignalTemporary;
    public UnityAction OnLogic;
    public UnityAction OffLogic;
    
    private bool _isTimerStop;    
    private float _duration;

    public Timer Timer => _timer;
    public bool IsPaid => _isPaid;
    public int Price => _price;
    public float TimeBlocked => _timeBlocked;

    protected void Awake()
    {        
        _isTimerStop = false;        
        _duration = _timeAction;       
    }

    protected void OnEnable()
    {
        _timer.StopTimer += StopOnBlock;

        if (_player.IsDead == false)
        {
            OnLogic?.Invoke();            

            if (_isTemporary)
            {
                OnSignalTemporary?.Invoke();                
            }

            if (_isBlocked)
            {
                _timer.enabled = true;
            }
        }       
    }

    private void FixedUpdate()
    {
        if (_isTemporary)
        {
            _duration -= Time.deltaTime;

            if (_duration <= 0)
            {
                OffSignalTemporary?.Invoke();
            }
        }

        if (_isTimerStop)
        {
            OffLogic?.Invoke();
            enabled = false;
        }

        if (_isTemporary == false && _isBlocked == false)
        {
            OffLogic?.Invoke();
            enabled = false;
        }
    }

    protected void OnDisable()
    {
        _timer.StopTimer -= StopOnBlock;
        OffSignalTemporary?.Invoke();
        _duration = _timeAction;
        _isTimerStop = false;        
    }

    public abstract void StartAction();

    protected bool TryPayAction()
    {
        bool result = false;

        if (_isPaid == true && _price <= _player.Wallet)
        {
            _player.PayCoins(_price);
            result = true;
        }
        else if (_isPaid == false)
        {
            result = true;
        }

        return result;
    }

    private void StopOnBlock()
    {
        _isTimerStop = true;
    }
}