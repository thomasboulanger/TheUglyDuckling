using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Toggle fullscreenToggle;

    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] _resolutions;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("fullscreenToggle.isOn")) fullscreenToggle.isOn = Screen.fullScreen;
        else fullscreenToggle.isOn = PlayerPrefs.GetInt("fullscreenToggle.isOn") == 1;

        resolutionDropdown.value = PlayerPrefs.GetInt("resolutionValue");
    }

    private void OnEnable()
    {
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        
        _resolutions = Screen.resolutions;

        foreach(var resolution in _resolutions)
        {
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolution.ToString()));
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("fullscreenToggle.isOn", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("resolutionValue", resolutionDropdown.value);
    }

    private void OnResolutionChange() => Screen.SetResolution(_resolutions[resolutionDropdown.value].width, _resolutions[resolutionDropdown.value].height, Screen.fullScreen);

    private void OnFullscreenToggle() => Screen.fullScreen = fullscreenToggle.isOn;
}