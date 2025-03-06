using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void OnEnable()
    {
        _counter.Changed += SetText;
    }

    private void OnDisable()
    {
        _counter.Changed -= SetText;
    }

    private void SetText()
    {
        _textMeshPro.text = _counter.Value.ToString();
    }
}
