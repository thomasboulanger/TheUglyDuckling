using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeatManager : MonoBehaviour
{
    public static float stacks;
    public static float UiStacks;
    public static float beatTimer;
    public static float beatInterval;
    public static bool aperture;
    
    public float BPM1;
    public float BPM2;
    public float BPM3;
    public AudioClip Music0;
    public AudioClip Music1;
    public AudioClip Music2;
    public AudioClip Music3;
    [Space]
    public float percentMargin;
    public RawImage test1;
    public RawImage test2;
    public RawImage test3;
    public RawImage test4;

    private static float _bpm1;
    private static float _bpm2;
    private static float _bpm3;
    private static AudioSource _audioSource;
    private int _sceneIndex;
    private Color _tmpColor;
    private float _beatMargin;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _audioSource = GetComponent<AudioSource>();
        _bpm1 = BPM1;
        _bpm2 = BPM2;
        _bpm3 = BPM3;
        
        _tmpColor = test1.GetComponent<RawImage>().color;

    }

    void Update()
    {
       

        if (beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;
            
        }

        if (_sceneIndex != 0)
        {
            beatTimer += Time.deltaTime;
            
            if (beatTimer <= _beatMargin * .5f || beatTimer >= beatInterval - (_beatMargin * 1.5f))
            {
                aperture = true;
                _tmpColor.a = 1f;
                aperture = true;
            }
            else
            {
                aperture = false;
                _tmpColor.a = 0f;
                aperture = false;
            }

            test1.GetComponent<RawImage>().color = _tmpColor;
            test2.GetComponent<RawImage>().color = _tmpColor;
            test3.GetComponent<RawImage>().color = _tmpColor;
            test4.GetComponent<RawImage>().color = _tmpColor;
            
            if (stacks > 0 )
            {
                if (stacks >= 12) 
                {
                    stacks = 12;
                }

                _audioSource.volume = .25f + (0.0625f * stacks);
            }
            else
            {
                _audioSource.volume = .25f;
            }
        }

       
    }

    public void GetSceneIndex()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;

        //for development only
        if (_sceneIndex > 3)
        {
            _sceneIndex = 3;
        }
        //end
        
        switch (_sceneIndex)
        {
            case 0:
                _audioSource.volume = 1f;
                _audioSource.clip = Music0;          
                _audioSource.Play();
                break;
            
            case 1:
                _audioSource.volume = .25f;
                _audioSource.clip = Music1;
                _audioSource.Play();
                beatInterval = 60 / _bpm1;
                _beatMargin = beatInterval * (percentMargin/100f);
                break;
            
            case 2:
                _audioSource.volume = .25f;
                _audioSource.clip = Music2;
                _audioSource.Play();
                beatInterval = 60 / _bpm2;
                _beatMargin = beatInterval * (percentMargin/100f);
                break;
            
            case 3:
                _audioSource.volume = .25f;
                _audioSource.clip = Music3;
                _audioSource.Play();
                beatInterval = 60 / _bpm3;
                _beatMargin = beatInterval * (percentMargin/100f);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
