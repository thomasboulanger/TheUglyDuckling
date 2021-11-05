using System.Collections.Generic;
using UnityEngine;

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
    private int _afkTimer;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
        
        if (Input.GetKeyDown(KeyCode.Z))
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

        if (Input.GetKeyDown(KeyCode.S))
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

        if (Input.GetKeyDown(KeyCode.Q))
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

        if (Input.GetKeyDown(KeyCode.D))
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
