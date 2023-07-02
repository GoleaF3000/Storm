using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerTrigger _playerTrigger;
    [SerializeField] private float _addToPositionX;    
    [SerializeField] private Vector3 _position;

    private void Start()
    {
        transform.position = new Vector3(_player.transform.position.x + _addToPositionX,
            _position.y, _position.z);
    }
    
    private void Update()
    {
        if (_playerTrigger.IsBase == false)
        {
            transform.position = new Vector3(_player.transform.position.x + _addToPositionX,
                _position.y, _position.z);
        }        
    }
}
