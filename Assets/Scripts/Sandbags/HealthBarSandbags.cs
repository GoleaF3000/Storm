using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSandbags : HealthBarSetter
{
    [SerializeField] private Sandbags _sandbags;

    private PlayerDefenseState _playerDefence;

    private new void Awake()
    {
        base.Awake();
        _playerDefence = FindObjectOfType<PlayerDefenseState>();
    }

    private void Start()
    {
        _slider.transform.position += _ofset;    
    }

    private void OnEnable()
    {
        _sandbags.SetMaxHealth += SetMaxValue;
        _sandbags.ChangeHealth += ChangeValue;
        _playerDefence.Undefensive += SwitchOffCanvas;
    }

    private void OnDisable()
    {
        _sandbags.SetMaxHealth -= SetMaxValue;
        _sandbags.ChangeHealth -= ChangeValue;
        _playerDefence.Undefensive -= SwitchOffCanvas;        
    }

    private void SwitchOffCanvas()
    {
        _canvas.enabled = false;
    }
}