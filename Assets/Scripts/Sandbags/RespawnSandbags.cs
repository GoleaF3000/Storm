using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSandbags : MonoBehaviour
{
    [SerializeField] private GameObject _sandbags;
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private int _countEnemy;

    private GameObject _newSandbags;
    private GameOverScreen _endScreen;
    private VictoryScreen _victoryScreen;
    private EnemyRespawn _respawn;

    private void Awake()
    {
        _endScreen = FindObjectOfType<GameOverScreen>();
        _victoryScreen = FindObjectOfType<VictoryScreen>();
    }

    private void OnEnable()
    {
        _endScreen.ClosedPanel += Create;
        _victoryScreen.ClosedPanel += Create;
    }

    private void Start()
    {
        Create();
    }

    private void OnDisable()
    {
        _endScreen.ClosedPanel -= Create;
        _victoryScreen.ClosedPanel -= Create;
    }

    private void Create()
    {
        if (_newSandbags != null)
        {
            Destroy(_newSandbags);
        }

        _newSandbags = Instantiate(_sandbags, transform);        
        _respawn = _newSandbags.GetComponentInChildren<EnemyRespawn>();
        _respawn.AssignCount(_countEnemy);
        _respawn.AssignPrefab(_prefabEnemy);
    }    
}