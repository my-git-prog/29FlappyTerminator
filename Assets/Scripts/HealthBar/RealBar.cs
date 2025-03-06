using UnityEngine;
using UnityEngine.UI;

public class RealBar : Bar
{
    [SerializeField] private Slider _slider;

    protected override void SetValue()
    {
        _slider.value = ((float)Health.Value / Health.MaximumValue);
    }
}
