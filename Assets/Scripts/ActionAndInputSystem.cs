using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ActionAndInputSystem : MonoBehaviour
{
    
    public AudioClip clipUp;
    public AudioClip clipDown;
    public AudioClip clipLeft;
    public AudioClip clipRight;
    public float percentMargin;
    public RawImage test1;
    public RawImage test2;
    public RawImage test3;
    public RawImage test4;

    private float _beatMargin;
    private AudioSource _audioSource;
    private bool _aperture;
    private Color _tmpColor;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _tmpColor = test1.GetComponent<RawImage>().color;
    }

    void Update()
    {
        _beatMargin = BeatManager.beatInterval * (percentMargin/100f);
        
        if (BeatManager.beatTimer <= _beatMargin * .5f || BeatManager.beatTimer >= BeatManager.beatInterval - (_beatMargin * 1.5f))
        {
            _aperture = true;
            _tmpColor.a = 1f;
        }
        else
        {
            _aperture = false;
            _tmpColor.a = 0f;
        }

        test1.GetComponent<RawImage>().color = _tmpColor;
        test2.GetComponent<RawImage>().color = _tmpColor;
        test3.GetComponent<RawImage>().color = _tmpColor;
        test4.GetComponent<RawImage>().color = _tmpColor;
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _audioSource.PlayOneShot(clipUp);
            if (BeatManager.beatTimer <= _beatMargin * .5f || BeatManager.beatTimer >= BeatManager.beatInterval - (_beatMargin * 1.5f))
            {
                BeatManager.stacks++;
            }
            else
            {
                BeatManager.stacks = 0;
            }
            Debug.Log(BeatManager.stacks);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _audioSource.PlayOneShot(clipDown);
            if (BeatManager.beatTimer <= _beatMargin * .5f || BeatManager.beatTimer >= BeatManager.beatInterval - (_beatMargin * 1.5f))
            {
                BeatManager.stacks++;
            }
            else
            {
                BeatManager.stacks = 0;
            }
            Debug.Log(BeatManager.stacks);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _audioSource.PlayOneShot(clipLeft);
            if (BeatManager.beatTimer <= _beatMargin * .5f || BeatManager.beatTimer >= BeatManager.beatInterval - (_beatMargin * 1.5f))
            {
                BeatManager.stacks++;
            }
            else
            {
                BeatManager.stacks = 0;
            }
            Debug.Log(BeatManager.stacks);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _audioSource.PlayOneShot(clipRight);
            if (BeatManager.beatTimer <= _beatMargin * .5f || BeatManager.beatTimer >= BeatManager.beatInterval - (_beatMargin * 1.5f))
            {
                BeatManager.stacks++;
            }
            else
            {
                BeatManager.stacks = 0;
            }
            Debug.Log(BeatManager.stacks);
        }
    }
}
