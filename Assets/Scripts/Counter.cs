using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _startValue = 0;

    private int _value;

    public event Action Changed;
 
    public int Value => _value;

    private void Awake()
    {
        Reset();
    }

    public void Add(int value = 1)
    {
        _value += value;
        Changed?.Invoke();
    }

    public void Reset()
    {
        _value = _startValue;
        Changed?.Invoke();
    }
}
