using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowStart : Window
{
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonOptions;

    public event Action StartButtonClicked;
    public event Action OptionsButtonClicked;

    private void Start()
    {
        _buttonStart.onClick.AddListener(OnStartButtonClicked);
        _buttonOptions.onClick.AddListener(OnOptionsButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        StartButtonClicked?.Invoke();
    }

    private void OnOptionsButtonClicked()
    {
        OptionsButtonClicked?.Invoke();
    }
}
