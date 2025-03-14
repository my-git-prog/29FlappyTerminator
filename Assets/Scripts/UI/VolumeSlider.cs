using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private const float Multiplier = 20f;
    private const float MaximumVolumeValue = 1f;
    private const float MinimumVolumeValue = 0.0001f;

    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Slider _slider;

    private string _parameter;

    protected float MinimumVolumeVal => MinimumVolumeValue;
    protected float CurrentVolumeVal => _slider.value;

    private void Awake()
    {
        _parameter = _mixerGroup.name;
    }

    protected virtual void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    protected virtual void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private float GetDbVolume(float volume)
    {
        return Mathf.Log10(Mathf.Clamp(volume, MinimumVolumeValue, MaximumVolumeValue)) * Multiplier;
    }

    protected void SetVolume(float volume)
    {
        _mixerGroup.audioMixer.SetFloat(_parameter, GetDbVolume(volume));
    }
}
