using UnityEngine.UI;

public class VolumeSlider : SoundUIElement
{
    private void OnEnable()
    {
        Slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        Slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        MixerGroup.audioMixer.SetFloat(Parameter, GetDbVolume(volume));
    }
}
