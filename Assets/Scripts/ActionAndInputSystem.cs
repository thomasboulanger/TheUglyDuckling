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
    public List<string> comboList = new List<string>();

    private AudioSource _audioSource;
    private bool _aperture;
    private string _combo = "";
    private int _comboStack;
    private int _afterComboTimer;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _aperture = BeatManager.aperture;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _audioSource.PlayOneShot(clipUp);
            if (_aperture)
            {
                BeatManager.stacks++;
                BeatManager.UiStacks++;
            }
            else
            {
                BeatManager.stacks = 0;
                BeatManager.UiStacks = 0;
            }
            Debug.Log(BeatManager.stacks);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _audioSource.PlayOneShot(clipDown);
            if (_aperture)
            {
                BeatManager.stacks++;
                BeatManager.UiStacks++;
            }
            else
            {
                BeatManager.stacks = 0;
                BeatManager.UiStacks = 0;
            }
            Debug.Log(BeatManager.stacks);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _audioSource.PlayOneShot(clipLeft);
            if (_aperture)
            {
                BeatManager.stacks++;
                BeatManager.UiStacks++;
            }
            else
            {
                BeatManager.stacks = 0;
                BeatManager.UiStacks = 0;
            }
            Debug.Log(BeatManager.stacks);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _audioSource.PlayOneShot(clipRight);
            if (_aperture)
            {
                BeatManager.stacks++;
                BeatManager.UiStacks++;
            }
            else
            {
                BeatManager.stacks = 0;
                BeatManager.UiStacks = 0;
            }
            Debug.Log(BeatManager.stacks);
        }
    }
}
