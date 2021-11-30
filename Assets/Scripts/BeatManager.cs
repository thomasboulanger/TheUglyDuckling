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
    public static int Stacks;
    public static int feverStacks;
    
    public float BPM1, BPM2, BPM3;
    public AudioClip Music0, Music1, Music2, Music3;
    [Space] 
    public float percentMargin;
    public float pulseMargin;

    private static float _bpm1, _bpm2, _bpm3;

    public static AudioSource AudioSource;
    private int _sceneIndex;
    private float _beatMargin;
    private float _pulseMargin;

    
    

    private void Awake()
    {                                                                                                                               
        DontDestroyOnLoad(gameObject);
        AudioSource = GetComponent<AudioSource>();
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

            if (Stacks > 0 )
            {
                if (Stacks >= 3) 
                {
                    Stacks = 3;
                    //UI fever ici
                }

                AudioSource.volume = .25f + (.25f * Stacks);
            }
            else
            {
                AudioSource.volume = .25f;
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
                AudioSource.volume = 1f;
                AudioSource.clip = Music0;          
                AudioSource.Play();
                break;
            
            case 1:
                AudioSource.volume = .25f;
                AudioSource.clip = Music1;
                AudioSource.Play();
                beatInterval = 60 / _bpm1;
                _beatMargin = beatInterval * (percentMargin/100f);
                _pulseMargin = beatInterval * (pulseMargin/100f);
                break;
            
            case 2:
                AudioSource.volume = .25f;
                AudioSource.clip = Music2;
                AudioSource.Play();
                beatInterval = 60 / _bpm2;
                _beatMargin = beatInterval * (percentMargin/100f);
                _pulseMargin = beatInterval * (pulseMargin/100f);
                break;
            
            case 3:
                AudioSource.volume = .25f;
                AudioSource.clip = Music3;
                AudioSource.Play();
                beatInterval = 60 / _bpm3;
                _beatMargin = beatInterval * (percentMargin/100f);
                _pulseMargin = beatInterval * (pulseMargin/100f);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
