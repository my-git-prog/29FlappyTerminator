using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : SoundUIElement
{
    [SerializeField] private Toggle _toggle;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ChangeState);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ChangeState);
    }

    private void ChangeState(bool state)
    {
        if (state)
        {
            MixerGroup.audioMixer.SetFloat(Parameter, GetDbVolume(Slider.value));
        }
        else
        {
            MixerGroup.audioMixer.SetFloat(Parameter, GetDbVolume(MinimumVolumeValue));
        }
    }
}
