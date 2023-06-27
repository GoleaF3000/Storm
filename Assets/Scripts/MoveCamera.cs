using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _addToPositionX;
    [SerializeField] private float _positionY;
    [SerializeField] private float _positionZ;    

    void Start()
    {
        transform.position = new Vector3(_player.transform.position.x + _addToPositionX, _positionY, _positionZ);
    }
    
    void Update()
    {
        if (FindObjectOfType<Player>() == true && _player.IsBase == false)
        {
            transform.position = new Vector3(_player.transform.position.x + _addToPositionX, _positionY, _positionZ);
        }        
    }
}
