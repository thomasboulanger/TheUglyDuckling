using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : Entity
{
    protected Animator Animator;
        
    protected bool IsActive;
        
    protected int AttackCount;
        
    [SerializeField] protected int maxActionRepetition = 2;
    [SerializeField] protected float distanceDetection = 10f;

    private State _currentState = State.Idle;

    private int _dodgeCount;
        
    private Transform _player;

    protected Weapon Weapon;

    [SerializeField] protected GameObject cubeDisplay;
    
    private enum State
    {
        Idle,
        Combat,
        Dead
    }

    protected void Awake()
    {
        Animator = GetComponent<Animator>();

        Weapon = GetComponentInChildren<Weapon>();
            
        _player = GameObject.FindGameObjectWithTag(Variables.PlayerTag).transform;

        ResetCounters();
    }

    protected virtual void Update()
    {
        switch (_currentState)
        {
            case (State.Idle):
                Idle();
                break;
            case (State.Combat):
                Combat();
                break;
            case (State.Dead):
                Dead();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
        
    #region States
    private void Idle()
    {
        CheckPlayerStatus();
    }
        
    private void Combat()
    {
        EnemyActions();
            
        CheckPlayerStatus();
    }

    private void Dead()
    {
        Animator.Play(Variables.DeadAnimName);
    }
    #endregion
        
    #region Actions
    protected virtual void RandomAction(int index)
    {
        

        if (index == Variables.FirstActionIndex){ Attack();}
        else Dodge();
    }
    
    protected virtual void RandomAction()
    {
        

        /*if (randomIndex == Variables.FirstActionIndex){ Attack();}
        else Dodge();*/
    }
        
    protected virtual void Attack()
    {
        UpdateCounters(true);
            
        IsActive = true;

        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
        
        Animator.Play(Variables.AttackAnimName);

        Weapon.Shoot();
    }
        
    protected void Dodge()
    {
        UpdateCounters(false);
            
        IsActive = true;
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
            
        Animator.Play(Variables.DodgeAnimName);
    }

    protected int actionCount;

    protected int randomIndex;
    
    protected virtual void EnemyActions()
    {
        if (IsActive) return;

        if (!(BeatManager.beatTimer >= BeatManager.beatInterval)) return;

        if (actionCount == 0)
        {
            randomIndex = Random.Range(Variables.FirstActionIndex, Variables.NbActions);
            
            cubeDisplay.GetComponent<SpriteRenderer>().color = randomIndex == 0 ? Color.red : Color.cyan;
            
            if(_dodgeCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
            else if(AttackCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        
        actionCount++;

        if (actionCount != 4) return;

        if(_dodgeCount == maxActionRepetition) Attack();
        else if(AttackCount == maxActionRepetition) Dodge();
        else RandomAction(randomIndex);
                
        actionCount = 0;
    }
    #endregion

    #region AnimationEvent
    [UsedImplicitly] private void EndAnimation() => IsActive = false;
    [UsedImplicitly] private void DestroyWhenDead() => Destroy(gameObject);
    #endregion
        
    #region Counters
    protected void UpdateCounters(bool isAttack)
    {
        if (isAttack)
        {
            _dodgeCount = Variables.ResetCounter;
            AttackCount++;
        }
        else
        {
            AttackCount = Variables.ResetCounter;
            _dodgeCount++;
        }
    }
        
    protected void ResetCounters()
    {
        _dodgeCount = Variables.ResetCounter;
        AttackCount = Variables.ResetCounter;
    }
    #endregion

    #region PlayerStatus
    private void CheckPlayerStatus()
    {
        IsPlayerDetected();
        IsPlayerDead();
    }
        
    private void IsPlayerDetected()
    {
        var playerPosition = _player.position;
        var enemyPosition = transform.position;

        _currentState = Vector3.Distance(playerPosition, enemyPosition) < distanceDetection ? State.Combat : State.Idle;
    }

    private void IsPlayerDead()
    {
        if (isDead) _currentState = State.Dead;
    }
    #endregion
        
    private void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-distanceDetection,0,0));
    }
}