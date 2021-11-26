using System;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pulsePanel;
    public GameObject cadrePanel;
    public Sprite transparentSquare;
    public Sprite inputUp;
    public Sprite inputBottom;
    public Sprite inputLeft;
    public Sprite inputRight;
    
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider specialHitSlider;

    private PlayerManager _player;
    private List<char> charList = new List<char>();
    private Color _tmpColor;
    
    private void Awake()
    {
        _player = FindObjectOfType<PlayerManager>();
        
        //SetMaxSliderValue(healthSlider, _player.Health);
        //SetMaxSliderValue(specialHitSlider, Variables.MaxSpecial);
    }

    private void Start()
    {
        _tmpColor = pulsePanel.transform.GetChild(0).GetComponent<RawImage>().color;

        for (int i = 0; i < cadrePanel.transform.childCount; i++) 
        {
            cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
        }
    }

    private void Update()
    {
        //SetCurrentSliderValue(healthSlider, _player.Health);
        //SetCurrentSliderValue(specialHitSlider, BeatManager.Stacks);
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


        for (int i = 0; i < PlayerManager.combo.Length; i++) 
        {
            if (PlayerManager.combo[i] == 'H')
            {
                cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inputUp;
            }
            else if (PlayerManager.combo[i] == 'B')
            {
                cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inputBottom;
            }
            else if (PlayerManager.combo[i] == 'G')
            {
                cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inputLeft;
            }
            else if (PlayerManager.combo[i] == 'D')
            {
                cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = inputRight;
            }
        }
        switch (PlayerManager.combo.Length)
        {
            case 0 :
                for (int i = 0; i < cadrePanel.transform.childCount; i++) 
                {
                    cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
                }
                break;
            case 1 :
                for (int i = 1; i < cadrePanel.transform.childCount; i++) 
                {
                    cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
                }
                break;
            case 2 :
                for (int i = 2; i < cadrePanel.transform.childCount; i++) 
                {
                    cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
                }
                break;
            case 3 :
                for (int i = 3; i < cadrePanel.transform.childCount; i++) 
                {
                    cadrePanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = transparentSquare;
                }
                break;
            default:
                break;
        }
    }

    private static void SetMaxSliderValue(Slider currentSlider, int maxValue) => currentSlider.maxValue = maxValue;

    private static void SetCurrentSliderValue(Slider currentSlider, int currentValue) => currentSlider.value = currentValue;
}