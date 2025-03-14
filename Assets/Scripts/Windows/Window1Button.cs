using System;
using UnityEngine;
using UnityEngine.UI;

public class Window1Button : Window
{
    [SerializeField] private Button _button1;

    public event Action Button1Clicked;

    protected virtual void OnEnable()
    {
        _button1.onClick.AddListener(OnButton1Clicked);
    }

    protected virtual void OnDisable()
    {
        _button1.onClick.RemoveListener(OnButton1Clicked);
    }

    private void OnButton1Clicked()
    {
        Button1Clicked?.Invoke();
    }
}
