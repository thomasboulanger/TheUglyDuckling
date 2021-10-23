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
    private static float _beatInterval;
    private float _volume;
    private float _rhythmStacks;
    private int _sceneIndex;

    public enum enumScene
    {
        MainMenu,
        Level1,
        Level2,
        Level3
    }

    public enumScene currentScene;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        _bpm1 = BPM1;
        _bpm2 = BPM2;
        _bpm3 = BPM3;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        _volume = GetComponent<AudioSource>().volume;
        _sceneIndex = 0;
    }

    void Update()
    {
        if (_sceneIndex != 0)
        {
            _beatTimer += Time.deltaTime;
        }
        
        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            //do the pulse here
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
                currentScene = enumScene.MainMenu;
                _audioSource.clip = Music0;          
                _audioSource.Play();
                break;
            
            case 1:
                currentScene = enumScene.Level1;
                _audioSource.clip = Music1;
                _audioSource.Play();
                _beatInterval = 60 / _bpm1;
                break;
            
            case 2:
                currentScene = enumScene.Level2;
                _audioSource.clip = Music2;
                _audioSource.Play();
                _beatInterval = 60 / _bpm2;
                break;
            
            case 3:
                currentScene = enumScene.Level3;
                _audioSource.clip = Music3;
                _audioSource.Play();
                _beatInterval = 60 / _bpm3;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
