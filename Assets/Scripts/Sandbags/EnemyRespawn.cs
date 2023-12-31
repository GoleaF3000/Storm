using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] private float _dispersionMinX;
    [SerializeField] private float _dispersionMaxX;
    [SerializeField] private float _dispersionMinY;
    [SerializeField] private float _dispersionMaxY;

    private GameObject _enemy;
    private int _countEnemy;
    private float _multiplicity = 100;
    private System.Random _random = new System.Random();

    public void AssignCount(int count)
    {
        _countEnemy = count;        
    }

    public void AssignPrefab(GameObject prefab)
    {
        _enemy = prefab;        
    }

    public void Create()
    {      
        for (int i = 0; i < _countEnemy; i++)
        {           
            float positionX = transform.position.x + ((Convert.ToSingle(_random.Next(Convert.ToInt32(_dispersionMinX * _multiplicity), Convert.ToInt32(_dispersionMaxX * _multiplicity)))) / _multiplicity);
            float positionY = transform.position.y + ((Convert.ToSingle(_random.Next(Convert.ToInt32(_dispersionMinY * _multiplicity), Convert.ToInt32(_dispersionMaxY * _multiplicity)))) / _multiplicity);
            Vector3 enemyPosition = new Vector3(positionX, positionY);

            Instantiate(_enemy, enemyPosition, Quaternion.identity);            
        }
    }
}