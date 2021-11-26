using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pulsePanel;
    
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider specialHitSlider;

    private PlayerManager _player;
    private Color _tmpColor;
    
    private void Awake()
    {
        _player = FindObjectOfType<PlayerManager>();

        SetMaxSliderValue(healthSlider, _player.Health);
        SetMaxSliderValue(specialHitSlider, Variables.MaxSpecial);
    }

    private void Start()
    {
        _tmpColor = pulsePanel.transform.GetChild(0).GetComponent<RawImage>().color;
    }

    private void Update()
    {
        SetCurrentSliderValue(healthSlider, _player.Health);
        SetCurrentSliderValue(specialHitSlider, BeatManager.Stacks);
        if (BeatManager.pulseAperture)
        {
            _tmpColor.a = 1f;
        }
        else
        {
            _tmpColor.a = 0f;
        }

        for (int i = 0; i < pulsePanel.transform.childCount; i++)
        {
           pulsePanel.transform.GetChild(i).GetComponent<RawImage>().color = _tmpColor;
        }
    }

    private static void SetMaxSliderValue(Slider currentSlider, int maxValue) => currentSlider.maxValue = maxValue;

    private static void SetCurrentSliderValue(Slider currentSlider, int currentValue) => currentSlider.value = currentValue;
}