using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private Color _color;

    private Timer _timer;
    private TMP_Text _text;
    private Color _originalColor;

    private void Awake()
    {
        _originalColor = _color;
        _timer = GetComponent<Timer>();
        _text = GetComponent<TMP_Text>();        
        RefreshDisplay(_timer.CountTime);
        Hide();
    }

    private void OnEnable()
    {
        _timer.StartTimer += Show;
        _timer.TimeProgress += RefreshDisplay;
        _timer.StopTimer += Hide;
    }

    private void OnDisable()
    {
        _timer.StartTimer -= Show;
        _timer.TimeProgress -= RefreshDisplay;
        _timer.StopTimer -= Hide;
    }

    private void Show()
    {
        _text.color = _originalColor;
    }

    private void RefreshDisplay(float time)
    {
        _text.text = Convert.ToString(Convert.ToInt32(time));
    }

    private void Hide()
    {
        _text.color = Color.clear;
    }
}