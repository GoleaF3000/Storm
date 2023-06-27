using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterButton : MonoBehaviour
{
    [SerializeField] private Color _colorOfBlock;

    private Image _image;
    private Button _button;
    private SkillButton _skillButton;
    private PlayerDefenseState _playerDefence;
    private GameOverScreen _endScreen;
    private VictoryScreen _victoryScreen;
    private Timer _timer;
    private Color _originalColor;
    private bool _isDefensive;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _skillButton = GetComponent<SkillButton>();
        _playerDefence = FindObjectOfType<PlayerDefenseState>();
        _endScreen = GameObject.FindObjectOfType<GameOverScreen>();
        _victoryScreen = GameObject.FindObjectOfType<VictoryScreen>();
        _timer = _skillButton.Timer;
        _originalColor = _image.color;
        _isDefensive = false;
        Block();
    }

    private void OnEnable()
    {
        _playerDefence.Undefensive += OffDefence;
        _playerDefence.Defensive += OnDefence;
        _timer.StartTimer += ChangeColor;
        _timer.StopTimer += ChangeColor;
        _endScreen.OpenPanel += Block;
        _endScreen.OpenPanel += StopLogic;
        _victoryScreen.OpenPanel += Block;
        _victoryScreen.OpenPanel += StopLogic;
        _playerDefence.Undefensive += Block;
        _playerDefence.Defensive += Unblock;
        _skillButton.OnLogic += Block;
        _skillButton.OffLogic += Unblock;
    }

    private void OnDisable()
    {
        _playerDefence.Undefensive -= OffDefence;
        _playerDefence.Defensive -= OnDefence;
        _timer.StartTimer -= ChangeColor;
        _timer.StopTimer -= ChangeColor;
        _endScreen.OpenPanel -= Block;
        _endScreen.OpenPanel -= StopLogic;
        _victoryScreen.OpenPanel -= Block;
        _victoryScreen.OpenPanel -= StopLogic;
        _playerDefence.Undefensive -= Block;
        _playerDefence.Defensive -= Unblock;
        _skillButton.OnLogic -= Block;
        _skillButton.OffLogic -= Unblock;
    }

    private void ChangeColor()
    {
        if (_image.color == _originalColor)
        {
            _image.color = _colorOfBlock;
        }
        else
        {
            _image.color = _originalColor;
        }
    }

    private void StopLogic()
    {
        _timer.enabled = false;
        _skillButton.enabled = false;
    }

    private void Block()
    {
        _button.enabled = false;
    }

    private void Unblock()
    {
        if (_isDefensive == true)
        {
            _button.enabled = true;
        }
    }

    private void OnDefence()
    {
        _isDefensive = true;
    }

    private void OffDefence()
    {
        _isDefensive = false;
    }
}