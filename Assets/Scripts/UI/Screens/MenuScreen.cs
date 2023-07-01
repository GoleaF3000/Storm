using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : Screen
{
    private void Awake()
    {        
        Open();
    }

    public new void Open()
    {
        if (_player.IsDead != true)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public new void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }   
}