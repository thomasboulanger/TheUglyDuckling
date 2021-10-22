using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatManager : MonoBehaviour
{
    public float BPM1;
    public float BPM2;
    public float BPM3;
    public AudioClip Music0;
    public AudioClip Music1;
    public AudioClip Music2;
    public AudioClip Music3;
    

    private static float _bpm1;
    private static float _bpm2;
    private static float _bpm3;
    private AudioSource _audioSource;
    private float _beatTimer;
    private float _beatInterval;
    private float _volume;
    private float _rhythmStacks;

    public enum enumScene
    {
        MainMenu,
        Level1,
        Level2,
        Level3
    }

    public enumScene currentScene;



    void Start()
    {
        _bpm1 = BPM1;
        _bpm2 = BPM2;
        _bpm3 = BPM3;
        _audioSource = GetComponent<AudioSource>();
        _volume = GetComponent<AudioSource>().volume;
        
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            _beatTimer += Time.deltaTime;
        }
        else
        {
            _beatTimer = 0f;
        }
        
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                _audioSource.clip = Music0;          
                _audioSource.Play();
                break;
            case 1:
                _audioSource.clip = Music1;
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
                
                _beatInterval = 60 / _bpm1;
                if (_beatTimer >= _beatInterval)
                {
                    _beatTimer -= _beatInterval;
                }
                break;
            case 2:
                _audioSource.clip = Music2;          
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
                
                _beatInterval = 60 / _bpm2;
                if (_beatTimer >= _beatInterval)
                {
                    _beatTimer -= _beatInterval;
                }
                break;
            case 03:
                _audioSource.clip = Music3;          
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
                
                _beatInterval = 60 / _bpm3;
                if (_beatTimer >= _beatInterval)
                {
                    _beatTimer -= _beatInterval;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
