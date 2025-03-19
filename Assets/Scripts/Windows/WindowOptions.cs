using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowOptions : Window
{
    [SerializeField] private Button _buttonOk;

    public event Action ButtonOkClicked;

    private void OnEnable()
    {
        _buttonOk.onClick.AddListener(OnButtonOkClicked);
    }

    private void OnDisable()
    {
        _buttonOk.onClick.RemoveListener(OnButtonOkClicked);
    }

    private void OnButtonOkClicked()
    {
        ButtonOkClicked?.Invoke();
    }
}
