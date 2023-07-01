using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Screen : MonoBehaviour
{
    [SerializeField] protected Player _player;
    [SerializeField] protected GameObject[] _elementsForManage;

    public UnityAction ClosedPanel;
    public UnityAction OpenPanel;  

    public void Open()
    {
        foreach (var element in _elementsForManage)
        {
            element.SetActive(true);
        }

        OpenPanel?.Invoke();
    }

    public void Close()
    {
        foreach (var element in _elementsForManage)
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