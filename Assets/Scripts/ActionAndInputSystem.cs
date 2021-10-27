using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
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
    private bool _delayAfterCombo;
    private int _afterComboTimer;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        _aperture = BeatManager.aperture;

        if (BeatManager.beatTimer >= BeatManager.beatInterval)
        {
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
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _audioSource.PlayOneShot(clipUp);
            if (_delayAfterCombo || !_aperture)
            {
                BreakCombo();
            }
            else
            {
                BeatManager.stacks++;
                _combo += "H";
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _audioSource.PlayOneShot(clipDown);
            if (_delayAfterCombo || !_aperture)
            {
                BreakCombo();
            }
            else
            {
                BeatManager.stacks++;
                _combo += "B";
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _audioSource.PlayOneShot(clipLeft);
            if (_delayAfterCombo || !_aperture)
            {
                BreakCombo();
            }
            else
            {
                BeatManager.stacks++;
                _combo += "G";
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _audioSource.PlayOneShot(clipRight);
            if (_delayAfterCombo || !_aperture)
            {
                BreakCombo();
            }
            else
            {
                BeatManager.stacks++;
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
                Avancer();
            }
            else if (_combo == comboList[1])
            {
                Attaquer();
            }
            else if (_combo == comboList[2])
            {
                Retraite();
            }
            else if (_combo == comboList[3])
            {
                CoupSpecial();
            }
        }
    }
    
    public void Avancer()
    {
        _combo = "";
        _delayAfterCombo = true;
    }
    public void Attaquer()
    {
        _combo = "";
        _delayAfterCombo = true;
    }
    public void Retraite()
    {
        _combo = "";
        _delayAfterCombo = true;
    }
    public void CoupSpecial()
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
