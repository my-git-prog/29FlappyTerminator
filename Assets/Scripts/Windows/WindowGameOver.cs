using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowGameOver : Window
{
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonAdvertisement;

    public event Action ButtonRestartClicked;
    public event Action ButtonAdvertisementClicked;

    private void OnEnable()
    {
        _buttonRestart.onClick.AddListener(OnButtonRestartClicked);
        _buttonAdvertisement.onClick.AddListener(OnButtonAdvertisementClicked);
    }

    private void OnDisable()
    {
        _buttonRestart.onClick.RemoveListener(OnButtonRestartClicked);
        _buttonAdvertisement.onClick.RemoveListener(OnButtonAdvertisementClicked);
    }

    private void OnButtonRestartClicked()
    {
        ButtonRestartClicked?.Invoke();
    }

    private void OnButtonAdvertisementClicked()
    {
        ButtonAdvertisementClicked?.Invoke();
    }
}
