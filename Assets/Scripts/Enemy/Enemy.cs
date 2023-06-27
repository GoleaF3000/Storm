using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private int _reward;

    public UnityAction<int> SetMaxHealth;
    public UnityAction<int> ChangeHealth;

    private Player _player;
    private Player _targetPlayer;
    private Sandbags _targetSanbags;
    private Animator _animator;   
    private GameOverScreen _endScreen;
    private float _currentDelay;

    public float SpeedPersonage => _speed;
    public Player TargetPlayer => _targetPlayer;
    public Sandbags TargetSandbags => _targetSanbags;

    private void Awake()
    {        
        _endScreen = GameObject.FindObjectOfType<GameOverScreen>();       
        _player = GameObject.FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _currentDelay = _delay;        
    }

    private void Start()
    {
        SetMaxHealth?.Invoke(_health);
    }

    private void OnEnable()
    {       
        _endScreen.ClosedPanel += Restart;
    }    

    private void OnDisable()
    {
        _endScreen.ClosedPanel -= Restart;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangeHealth?.Invoke(_health);

        if (_health <= 0)
        {
            _player.PutReward(_reward);
            Destroy(gameObject);
        }
    }

    public void Hit()
    {
        if (_currentDelay <= 0)
        {

            if (_targetPlayer != null)
            {
                _targetPlayer.TakeDamage(_damage);
            }

            if (_targetSanbags != null)
            {
                _targetSanbags.TakeDamage(_damage);
            }

            _animator.Play("Hit");
            _currentDelay = _delay;
        }

        _currentDelay -= Time.deltaTime;
    }

    public void SetTargetPlayer(Player player)
    {
        _targetPlayer = player;
    }

    public void SetTargetSandbags(Sandbags sandbags)
    {
        _targetSanbags = sandbags;
    }

    public void Restart()
    {
        Destroy(gameObject);
    }
}