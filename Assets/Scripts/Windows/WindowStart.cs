using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowStart : Window
{
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonOptions;

    public event Action ButtonStartClicked;
    public event Action ButtonOptionsClicked;

    private void OnEnable()
    {
        _buttonStart.onClick.AddListener(OnButtonStartClicked);
        _buttonOptions.onClick.AddListener(OnButtonOptionsClicked);
    }

    private void OnDisable()
    {
        _buttonStart.onClick.RemoveListener(OnButtonStartClicked);
        _buttonOptions.onClick.RemoveListener(OnButtonOptionsClicked);
    }

    private void OnButtonStartClicked()
    {
        ButtonStartClicked?.Invoke();
    }

    private void OnButtonOptionsClicked()
    {
        ButtonOptionsClicked?.Invoke();
    }
}
