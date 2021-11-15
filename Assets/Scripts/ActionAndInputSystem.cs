using System.Collections.Generic;
using Scenes.Jordan.Scripts;
using UnityEngine;

public class ActionAndInputSystem : Entity
{
    public AudioClip clipUp;
    public AudioClip clipDown;
    public AudioClip clipLeft;
    public AudioClip clipRight;
    public List<string> comboList = new List<string>();

    private AudioSource _audioSource;
    private bool _aperture;
    private string _combo = "";
    private bool _delayAfterCombo;
    private int _afterComboTimer;
    private int _afkTimer;
    private Animator _animator;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _aperture = BeatManager.aperture;

        if (BeatManager.beatTimer >= BeatManager.beatInterval)
        {
            _afkTimer++;
            if (_delayAfterCombo)
            {
                _afterComboTimer++;
            }
        }

        if (_afterComboTimer == 4)
        {
            _delayAfterCombo = false;
            _afterComboTimer = 0;
        }

        if (_afkTimer >= 2)
        {
            _combo = "";
        }
        
        if (InputManager.upInput)
        {
            _audioSource.PlayOneShot(clipUp);
            if (_delayAfterCombo || !_aperture)
            {
                BreakCombo();
            }
            else
            {
                _afkTimer = 0;
                _combo += "H";
            }
        }

        if (InputManager.downInput)
        {
            _audioSource.PlayOneShot(clipDown);
            if (_delayAfterCombo || !_aperture)
            {
                BreakCombo();
            }
            else
            {
                _afkTimer = 0;
                _combo += "B";
            }
        }

        if (InputManager.leftInput)
        {
            _audioSource.PlayOneShot(clipLeft);
            if (_delayAfterCombo || !_aperture)
            {
                BreakCombo();
            }
            else
            {
                _afkTimer = 0;
                _combo += "G";
            }
        }

        if (InputManager.rightInput)
        {
            _audioSource.PlayOneShot(clipRight);
            if (_delayAfterCombo || !_aperture)
            {
                BreakCombo();
            }
            else
            {
                _afkTimer = 0;
                _combo += "D";
            }
        }

        if (_combo.Length >= 4)
        {
            if (_combo.Length > 4)
            {
                _combo = _combo.Substring(1);
            }
            
            if (_combo == comboList[0])
            {
                BeatManager.stacks++;
                Avancer();
            }
            else if (_combo == comboList[1])
            {
                BeatManager.stacks++;
                Attaquer();
            }
            else if (_combo == comboList[2])
            {
                BeatManager.stacks++;
                Retraite();
            }
            else if (_combo == comboList[3])
            {
                BeatManager.stacks++;
                CoupSpecial();
            }
        }
    }
    
    public void Avancer()
    {
        OnCombo();
    }
    public void Attaquer()
    {
        OnCombo();
    }
    public void Retraite()
    {
        OnCombo();
    }
    public void CoupSpecial()
    {
        OnCombo();
    }
    
    private void OnCombo()
    {
        _combo = "";
        _delayAfterCombo = true;
    }
    private void BreakCombo()
    {
        BeatManager.stacks = 0;
        _combo = "";
    }
}