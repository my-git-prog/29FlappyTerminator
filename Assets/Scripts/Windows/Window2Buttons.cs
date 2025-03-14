using System;
using UnityEngine;
using UnityEngine.UI;

public class Window2Buttons : Window1Button
{
    [SerializeField] private Button _button2;

    public event Action Button2Clicked;

    protected override void OnEnable()
    {
        base.OnEnable();
        _button2.onClick.AddListener(OnButton2Clicked);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _button2.onClick.AddListener(OnButton2Clicked);
    }

    private void OnButton2Clicked()
    {
        Button2Clicked?.Invoke();
    }
}
