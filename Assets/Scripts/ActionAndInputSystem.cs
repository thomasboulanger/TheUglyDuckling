using System.Collections.Generic;
using Scenes.Jordan.Scripts;
using UnityEngine;

public class ActionAndInputSystem : Entity
{
    public static bool isCameraFreezed = false;
    public static Vector3 freezeCameraPos;

    public AudioClip clipUp;
    public AudioClip clipDown;
    public AudioClip clipLeft;
    public AudioClip clipRight;
    public List<string> comboList = new List<string>();
    [Space]
    public float speed = 1f;
    [Space]

    private AudioSource _audioSource;
    private bool _aperture;
    private string _combo = "";
    private bool _delayAfterCombo;
    private int _afterComboTimer;
    private int _afkTimer;
    private Animator _animator;
    private bool _animIdle, _animWalkForward, _animWalkBackward, _animAttack, _animSpecialAttack, _animIsDead;
    private Rigidbody2D _rb2D;
    
    private enum State
    {
        Idle,
        WalkForward,
        WalkBackward,
        Attack,
        SpecialAttack,
        IsDead
    }

    private State currentState = State.Idle;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("Idle",_animIdle);
        _animator.SetBool("WalkForward",_animWalkForward);
        _animator.SetBool("WalkBackward",_animWalkBackward);
        _animator.SetBool("Attack",_animAttack);
        _animator.SetBool("SpecialAttack",_animSpecialAttack);
        _animator.SetBool("IsDead",_animIsDead);
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

        switch (currentState)
        {
            case State.Idle:
                _animIdle = true;
                _rb2D.velocity = Vector2.zero;
                break;
            case State.WalkForward:
                if (_delayAfterCombo)
                {
                    _animWalkForward = true;
                    _rb2D.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
                }
                else
                {
                    _animWalkForward = false;
                    currentState = State.Idle;
                }
                break;
            
            case State.WalkBackward:
                if (_delayAfterCombo)
                {
                    _animWalkBackward = true;
                    //a définir la retraite plus tard
                    if (_afterComboTimer <= 2)
                    {
                        _rb2D.MovePosition(transform.position - (Vector3.right * speed * Time.deltaTime) * 2f);
                    }
                    else
                    {
                        _rb2D.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime) * 2f);
                    }
                }
                else
                {
                    _animWalkBackward = false;
                    isCameraFreezed = false;
                    currentState = State.Idle;
                }
                break;
            
            case State.Attack:
                if (_delayAfterCombo)
                {
                    _animAttack = true;
                   //shoot
                }
                else
                {
                    _animAttack = false;
                    currentState = State.Idle;
                }
                break;
            
            case State.SpecialAttack:
                if (_delayAfterCombo)
                {
                    _animSpecialAttack = true;
                   // special shoot
                }
                else
                {
                    _animSpecialAttack = false;
                    currentState = State.Idle;
                }
                break;
            
            case State.IsDead:
                //do the dead
                break;
            default:
                Debug.Log("ton switch deconne");
                break;
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
        OnCombo();
        currentState = State.WalkForward;
    }
    public void Attaquer()
    {
        OnCombo();
        currentState = State.Attack;
    }
    public void Retraite()
    {
        OnCombo();
        freezeCameraPos = transform.position;
        isCameraFreezed = true;
        currentState = State.WalkBackward;
    }
    public void CoupSpecial()
    {
        OnCombo();
        currentState = State.SpecialAttack;
    }
    
    private void OnCombo()
    {
        _combo = "";
        _delayAfterCombo = true;
        BeatManager.stacks++;
        _animIdle = false;
    }
    private void BreakCombo()
    {
        BeatManager.stacks = 0;
        _combo = "";
        _delayAfterCombo = false;
    }
}