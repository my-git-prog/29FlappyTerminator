using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowGameOver : Window
{
    [SerializeField] private Button _buttonRetart;
    [SerializeField] private Button _buttonAdvertisement;

    public event Action RetartButtonClicked;
    public event Action AdvertisementButtonClicked;

    private void Start()
    {
        _buttonRetart.onClick.AddListener(OnRestartButtonClicked);
        _buttonAdvertisement.onClick.AddListener(OnAdvertisementButtonClicked);
    }

    private void OnRestartButtonClicked()
    {
        RetartButtonClicked?.Invoke();
    }

    private void OnAdvertisementButtonClicked()
    {
        AdvertisementButtonClicked?.Invoke();
    }
}
