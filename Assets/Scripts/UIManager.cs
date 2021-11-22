using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider specialHitSlider;

    private ActionAndInputSystem _player;
    
    private void Awake()
    {
        _player = FindObjectOfType<ActionAndInputSystem>();

        SetMaxSliderValue(healthSlider, _player.Health);
    }

    private void Update()
    {
        SetCurrentSliderValue(healthSlider, _player.Health);
    }

    private static void SetMaxSliderValue(Slider currentSlider, int maxValue)
    {
        currentSlider.maxValue = maxValue;
        currentSlider.value = maxValue;
    }

    private static void SetCurrentSliderValue(Slider currentSlider, int currentValue)
    {
        currentSlider.value = currentValue;
    }
}