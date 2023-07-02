using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private SkillButton _skillButton;

    public event UnityAction<float> TimeProgress;
    public event UnityAction StartTimer;
    public event UnityAction StopTimer;

    private float _countTime;

    public float CountTime => _countTime;

    private void OnEnable()
    {
        _countTime = _skillButton.TimeBlocked;
        StartTimer?.Invoke();
    }

    private void Update()
    {
        TimeProgress?.Invoke(_countTime);
        _countTime -= Time.deltaTime;

        if (_countTime <= 0)
        {
            enabled = false;
        }
    }

    private void OnDisable()
    {
        StopTimer?.Invoke();
    }
}