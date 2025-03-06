using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowOptions : Window
{
    [SerializeField] private Button _buttonOk;

    public event Action OkButtonClicked;

    private void Start()
    {
        _buttonOk.onClick.AddListener(OnOkButtonClicked);
    }

    private void OnOkButtonClicked()
    {
        OkButtonClicked?.Invoke();
    }
}
