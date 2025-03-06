using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField] private PlayerView _view;
    [SerializeField] private Gun _gun;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private Toggle _autoShoootingToggle;
    [SerializeField] private float _autoShootingDeltaTime = 0.3f;

    public event Action GameOver;

    private void Awake()
    {
        _autoShoootingToggle.onValueChanged.AddListener(OnAutoShootingToggleChanging);
    }

    private void OnEnable()
    {
        _userInput.GasButtonPressed += _mover.Gas;
        _userInput.AttackButtonPressed += _gun.Shoot;
        Health.Died += OverGame;
        _collisionHandler.Crashed += OverGame;
    }

    private void OnDisable()
    {
        _userInput.GasButtonPressed -= _mover.Gas;
        _userInput.AttackButtonPressed -= _gun.Shoot;
        Health.Died -= OverGame;
        _collisionHandler.Crashed += OverGame;
    }

    private void OverGame()
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        Health.Reset();
        _mover.Reset();
    }

    private void OnAutoShootingToggleChanging(bool state)
    {
        if (state)
        {
            _userInput.AttackButtonPressed -= _gun.Shoot;
            _gun.StartShooting(_autoShootingDeltaTime);
        }
        else
        {
            _userInput.AttackButtonPressed += _gun.Shoot;
            _gun.StopShooting();
        }
    }
}
