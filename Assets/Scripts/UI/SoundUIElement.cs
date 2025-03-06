using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundUIElement : MonoBehaviour
{
    private const float Multiplier = 20f;
    private const float MaximumVolumeValue = 1f;

    protected const float MinimumVolumeValue = 0.0001f;

    [SerializeField] protected AudioMixerGroup MixerGroup;
    [SerializeField] protected Slider Slider;

    protected string Parameter;

    private void Awake()
    {
        Parameter = MixerGroup.name;
    }

    protected float GetDbVolume(float volume)
    {
        return Mathf.Log10(Mathf.Clamp(volume, MinimumVolumeValue, MaximumVolumeValue)) * Multiplier;
    }
}
