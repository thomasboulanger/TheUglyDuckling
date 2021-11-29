using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : Entity
{
    protected Animator animator;
        
    protected bool isActive;
        
    protected int attackCount;
        
    [SerializeField] protected int maxActionRepetition = 2;
    [SerializeField] protected float distanceDetection = 10f;

    private State _currentState = State.Idle;

    protected int dodgeCount;
        
    private Transform _player;

    protected Weapon weapon;

    [SerializeField] protected GameObject cubeDisplay;
    
    private enum State
    {
        Idle,
        Combat,
        Dead
    }

    protected void Awake()
    {
        animator = GetComponent<Animator>();

        weapon = GetComponentInChildren<Weapon>();
            
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
        animator.Play(Variables.DeadAnimName);
    }
    #endregion
        
    #region Actions
    protected virtual void RandomAction(int randomIndex)
    {
        

        if (randomIndex == Variables.FirstActionIndex){ Attack();}
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
            
        isActive = true;

        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
        
        animator.Play(Variables.AttackAnimName);

        weapon.Shoot();
    }
        
    protected void Dodge()
    {
        UpdateCounters(false);
            
        isActive = true;
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
            
        animator.Play(Variables.DodgeAnimName);
    }

    protected int actionCount;

    protected int randomIndex;
    
    protected virtual void EnemyActions()
    {
        if (isActive) return;

        if (!(BeatManager.beatTimer >= BeatManager.beatInterval)) return;

        if (actionCount == 0)
        {
            randomIndex = Random.Range(Variables.FirstActionIndex, Variables.NbActions);
            
            cubeDisplay.GetComponent<SpriteRenderer>().color = randomIndex == 0 ? Color.red : Color.cyan;
            
            if(dodgeCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
            else if(attackCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        
        actionCount++;

        if (actionCount != 4) return;

        if(dodgeCount == maxActionRepetition) Attack();
        else if(attackCount == maxActionRepetition) Dodge();
        else RandomAction(randomIndex);
                
        actionCount = 0;
    }
    #endregion

    #region AnimationEvent
    [UsedImplicitly] private void EndAnimation() => isActive = false;
    [UsedImplicitly] private void DestroyWhenDead() => Destroy(gameObject);
    #endregion
        
    #region Counters
    protected void UpdateCounters(bool isAttack)
    {
        if (isAttack)
        {
            dodgeCount = Variables.ResetCounter;
            attackCount++;
        }
        else
        {
            attackCount = Variables.ResetCounter;
            dodgeCount++;
        }
    }
        
    protected void ResetCounters()
    {
        dodgeCount = Variables.ResetCounter;
        attackCount = Variables.ResetCounter;
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