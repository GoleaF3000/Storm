using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private bool _isBase = false;

    public bool IsBase => _isBase;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TriggerBase>(out TriggerBase triggerBase))
        {
            _isBase = true;
        }
    }

    public void Restart()
    {
        _isBase = false;
    }        
}