using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _value = 10;
    [SerializeField] private int _maximumValue = 10;
    [SerializeField] private int _minimumValue = 0;

    public event Action Died;
    public event Action ValueChanged;

    public int Value => _value;
    public int MaximumValue => _maximumValue;

    public void TakeDamage(int damage)
    {
        _value = Math.Clamp(_value - Math.Clamp(damage, _minimumValue, _maximumValue), _minimumValue, _maximumValue);
        ValueChanged?.Invoke();

        if (_value == _minimumValue)
            Died?.Invoke();
    }

    public void Reset()
    {
        _value = _maximumValue;
        ValueChanged?.Invoke();
    }
}
