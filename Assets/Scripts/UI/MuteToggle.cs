using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : VolumeSlider
{
    [SerializeField] private Toggle _toggle;

    protected override void OnEnable()
    {
        base.OnEnable();
        _toggle.onValueChanged.AddListener(ChangeState);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _toggle.onValueChanged.RemoveListener(ChangeState);
    }

    private void ChangeState(bool isChecked)
    {
        if (isChecked)
            Unmute();
        else
            Mute();
    }
    private void Mute()
    {
        SetVolume(MinimumVolumeVal);
    }

    private void Unmute()
    {
        SetVolume(CurrentVolumeVal);
    }
}
