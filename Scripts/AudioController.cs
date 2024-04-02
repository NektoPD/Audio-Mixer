using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    private const string MasterVolumeParameter = "MasterVolume";
    private const string BackgroundVolumeParameter = "MusicVolume";
    private const string ButtonsVolume = "AllButtonsVolume";

    [SerializeField] private AudioMixerGroup _mixer;

    private float _minVolume = -80;
    private float _maxVolume = 0;
    private bool _isMaxVolume = true;

    public void ToggleMusicState()
    {
        if (!_isMaxVolume)
        {
            _isMaxVolume = true;
            SetMasterVolume(_maxVolume);
        }
        else
        {
            _isMaxVolume = false;
            SetMasterVolume(_minVolume);
        }
    }

    public void SetTotalVolume(float volume)
    {
        SetSliderVolume(MasterVolumeParameter, volume);
    }

    public void SetButtonsVolume(float volume)
    {
        SetSliderVolume(ButtonsVolume, volume);
    }

    public void SetBackgroundVolume(float volume)
    {
        SetSliderVolume(BackgroundVolumeParameter, volume);
    }

    private void SetSliderVolume(string parameterName, float volume)
    {
        _mixer.audioMixer.SetFloat(parameterName, Mathf.Lerp(_minVolume, _maxVolume, volume));
    }

    private void SetMasterVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(MasterVolumeParameter, volume);
    }
}
