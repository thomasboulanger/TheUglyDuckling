using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private string volumeParameter = "MasterVolume";

    [SerializeField] private AudioMixer mixer;

    [SerializeField] private Slider slider;

    private const float Multiplier = 30f;
    
    private void Awake() => slider.onValueChanged.AddListener(HandleSliderValueChanged);

    private void OnDisable() => PlayerPrefs.SetFloat(volumeParameter, slider.value);

    private void HandleSliderValueChanged(float value) => mixer.SetFloat(volumeParameter, Mathf.Log10(value) * Multiplier);

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);

        mixer.SetFloat(volumeParameter, Mathf.Log10(slider.value) * Multiplier);
    }
}