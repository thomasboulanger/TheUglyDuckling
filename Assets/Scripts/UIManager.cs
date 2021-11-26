using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider specialHitSlider;

    private PlayerManager _player;
    
    private void Awake()
    {
        _player = FindObjectOfType<PlayerManager>();

        SetMaxSliderValue(healthSlider, _player.Health);
        SetMaxSliderValue(specialHitSlider, Variables.MaxSpecial);
    }

    private void Update()
    {
        SetCurrentSliderValue(healthSlider, _player.Health);
        SetCurrentSliderValue(specialHitSlider, BeatManager.Stacks);
    }

    private static void SetMaxSliderValue(Slider currentSlider, int maxValue) => currentSlider.maxValue = maxValue;

    private static void SetCurrentSliderValue(Slider currentSlider, int currentValue) => currentSlider.value = currentValue;
}