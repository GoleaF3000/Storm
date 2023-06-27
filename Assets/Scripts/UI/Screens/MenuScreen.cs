using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : Screen
{
    protected void Awake()
    {
        base.Awake();        
        Open();
    }

    public new void Open()
    {
        if (_player.IsDead != true)
        {
            _panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public new void Close()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
    }   
}