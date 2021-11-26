using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeatManager : MonoBehaviour
{
    
    public static float beatTimer;
    public static float beatInterval;
    public static bool aperture;
    public static bool pulseAperture;
    
    public float BPM1, BPM2, BPM3;
    public AudioClip Music0, Music1, Music2, Music3;
    [Space] 
    public float percentMargin;
    public float pulseMargin;

    private static float _bpm1, _bpm2, _bpm3;

    private static AudioSource _audioSource;
    private int _sceneIndex;
    private float _beatMargin;
    private float _pulseMargin;

    private static int _stacks;
    
    public static int Stacks
    {
        get => _stacks;
        set
        {
            _stacks = value;

            //PlayerManager.canSpecial = _stacks >= Variables.MaxSpecial;
            PlayerManager.canSpecial = true;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
        _bpm1 = BPM1;
        _bpm2 = BPM2;
        _bpm3 = BPM3;
    }

    private void Update()
    {

        if (beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;
        }

        if (_sceneIndex != 0)
        {
            beatTimer += Time.deltaTime;
            
            if (beatTimer <= _beatMargin || beatTimer >= beatInterval - (_beatMargin))
            {
                aperture = true;
            }
            else
            {
                aperture = false;
            }
             
            if (beatTimer <= _pulseMargin || beatTimer >= beatInterval - (_pulseMargin))
            {
                pulseAperture = true;
            }
            else
            {
                pulseAperture = false;
            }

            if (_stacks > 0 )
            {
                if (_stacks >= 3) 
                {
                    _stacks = 3;
                    //UI fever ici
                    
                }

                _audioSource.volume = .25f + (.25f * _stacks);
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
            _sceneIndex = 2;
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
                _pulseMargin = beatInterval * (pulseMargin/100f);
                break;
            
            case 2:
                _audioSource.volume = .25f;
                _audioSource.clip = Music2;
                _audioSource.Play();
                beatInterval = 60 / _bpm2;
                _beatMargin = beatInterval * (percentMargin/100f);
                _pulseMargin = beatInterval * (pulseMargin/100f);
                break;
            
            case 3:
                _audioSource.volume = .25f;
                _audioSource.clip = Music3;
                _audioSource.Play();
                beatInterval = 60 / _bpm3;
                _beatMargin = beatInterval * (percentMargin/100f);
                _pulseMargin = beatInterval * (pulseMargin/100f);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
