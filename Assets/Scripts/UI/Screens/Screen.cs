using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Screen : MonoBehaviour
{
    [SerializeField] protected GameObject _panel;
    [SerializeField] protected GameObject[] _elements;

    public UnityAction ClosedPanel;
    public UnityAction OpenPanel;

    protected Player _player;

    protected void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public void Open()
    {
        foreach (var element in _elements)
        {
            element.SetActive(true);
        }

        OpenPanel?.Invoke();
    }

    public void Close()
    {
        foreach (var element in _elements)
        {
            element.SetActive(false);
        }

        ClosedPanel?.Invoke();
    }

    public void Exit()
    {
        Application.Quit();
    }
}