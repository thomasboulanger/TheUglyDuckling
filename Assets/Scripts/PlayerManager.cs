using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Entity
{
    public static bool isCameraFreezed = false;
    public static Vector2 freezeCameraPos;
    public static string combo = "";

    public AudioClip clipUp;
    public AudioClip clipDown;
    public AudioClip clipLeft;
    public AudioClip clipRight;
    public List<string> comboList = new List<string>();
    [Space]
    public float speed;
    [Space]

    private AudioSource _audioSource;
    private bool _aperture;
    private bool _delayAfterCombo;
    private int _afterComboTimer;
    private int _afkTimer;
    private Animator _animator;
    private bool _animIdle, _animWalkForward, _animWalkBackward, _animAttack, _animSpecialAttack, _animIsDead;
    private Rigidbody2D _rb2D;
    private float _lerpValue = 0f;
    private bool _trigger;
    private float _fireRateTimer;

    public static bool canSpecial;

    private int _feverCount;

    private Weapon _weapon;

    private enum State
    {
        Idle,
        WalkForward,
        WalkBackward,
        Attack,
        SpecialAttack,
        IsDead
    }

    private State _currentState = State.Idle;
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int WalkForward = Animator.StringToHash("WalkForward");
    private static readonly int WalkBackward = Animator.StringToHash("WalkBackward");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int SpecialAttack = Animator.StringToHash("SpecialAttack");
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _weapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
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
            combo = "";
        }

        switch (_currentState)
        {
            case State.Idle:
                _animIdle = true;
                _animator.SetBool(Idle,_animIdle);
                _rb2D.velocity = Vector2.zero;
                break;
            case State.WalkForward:
                if (_delayAfterCombo)
                {
                    _animWalkForward = true;
                    _animator.SetBool(WalkForward,_animWalkForward);
                    _rb2D.velocity =  Vector2.right * speed /* Time.deltaTime*/;
                }
                else
                {
                    _animWalkForward = false;
                    _animator.SetBool(WalkForward,_animWalkForward);
                    _currentState = State.Idle;
                }
                break;
            
            case State.WalkBackward:
                if (_delayAfterCombo)
                {
                    if (_lerpValue > 1f)
                    {
                        _lerpValue = 1f;
                    }
                    if (_afterComboTimer <= 1)
                    {
                        _animWalkBackward = true;
                        _animator.SetBool(WalkBackward,_animWalkBackward);
                        _rb2D.MovePosition(Vector2.Lerp(freezeCameraPos,
                            new Vector2(freezeCameraPos.x - 6.5f, freezeCameraPos.y),
                            _lerpValue += Time.deltaTime /.4f));
                    }
                    else
                    {
                        _animWalkBackward = false;
                        _animator.SetBool(WalkBackward,_animWalkBackward);
                        _animWalkForward = true;
                        _animator.SetBool(WalkForward,_animWalkForward);
                        _rb2D.MovePosition(Vector2.Lerp(freezeCameraPos,
                            new Vector2(freezeCameraPos.x - 6.5f, freezeCameraPos.y),
                            _lerpValue -= Time.deltaTime /.4f));
                    }
                }
                else
                {
                    _animWalkForward = false;
                    _animator.SetBool(WalkForward,_animWalkForward);
                    isCameraFreezed = false;
                    _trigger = true;
                    _lerpValue = 0f;
                    _currentState = State.Idle;
                }
                break;
            
            case State.Attack:
                if (_delayAfterCombo)
                { 
                    _animAttack = true;
                    _animator.SetBool(Attack,_animAttack);
                    _fireRateTimer += Time.deltaTime;
                    float fireRate = _weapon.fireRate;
                   if (_fireRateTimer >= fireRate)
                    {
                        _fireRateTimer -= fireRate;
                        _weapon.Shoot();
                    }
                }
                else
                {
                    _animAttack = false;
                    _animator.SetBool(Attack,_animAttack);
                    _currentState = State.Idle;
                    _fireRateTimer = 0f;
                }
                break;
            
            case State.SpecialAttack:
                if (_delayAfterCombo && canSpecial)
                {
                    _animSpecialAttack = true;
                    _animator.SetBool(SpecialAttack,_animSpecialAttack);
                    // special shoot
                    _weapon.SpecialAttack();
                    BeatManager.Stacks = 0;
                }
                else
                {
                    _animSpecialAttack = false;
                    _animator.SetBool(SpecialAttack,_animSpecialAttack);
                    _currentState = State.Idle;
                }
                break;
            
            case State.IsDead:
                //do the dead
                _animIsDead = true;
                _animator.SetBool(IsDead,_animIsDead);
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
                combo += "H";
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
                combo += "B";
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
                combo += "G";
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
                combo += "D";
            }
        }

        if (combo.Length >= 4)
        {
            if (combo.Length > 4)
            {
                combo = combo.Substring(1);
            }
            
            if (combo == comboList[0])
            {
                Avancer();
            }
            else if (combo == comboList[1])
            {
                Attaquer();
            }
            else if (combo == comboList[2])
            {
                Retraite();
            }
            else if (combo == comboList[3])
            {
                CoupSpecial();
            }
        }
    }
    
    public void Avancer()
    {
        OnCombo();
        _currentState = State.WalkForward;
    }
    public void Attaquer()
    {
        OnCombo();
        _currentState = State.Attack;
    }
    public void Retraite()
    {
        OnCombo();
        freezeCameraPos = transform.position;
        isCameraFreezed = true;
        _currentState = State.WalkBackward;
    }
    public void CoupSpecial()
    {
        OnCombo();
        _currentState = State.SpecialAttack;
    }
    
    private void OnCombo()
    {
        combo = "";
        _delayAfterCombo = true;
        BeatManager.Stacks++;
        _animIdle = false;
        _animator.SetBool(Idle,_animIdle);
    }
    private void BreakCombo()
    {
        BeatManager.Stacks = 0;
        combo = "";
        _delayAfterCombo = false;
    }
}