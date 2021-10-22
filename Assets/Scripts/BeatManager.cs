using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public float BPM1;
    public float BPM2;
    public float BPM3;
    public AudioClip Music1;
    public AudioClip Music2;
    public AudioClip Music3;
    

    private static float _bpm1;
    private static float _bpm2;
    private static float _bpm3;
    private AudioSource _audioSource;
    private float _beatTimer;
    private float _beatInterval;
    void Start()
    {
        _bpm1 = BPM1;
        _bpm2 = BPM2;
        _bpm3 = BPM3;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(Music1,1f);
    }

    void Update()
    {
        _beatTimer += Time.deltaTime;
        _beatInterval = 60 / BPM1;
        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            _audioSource.PlayOneShot(Music2,1f);
        }
        transform.position = new Vector3(0f,_beatTimer,0f);

    }
}
