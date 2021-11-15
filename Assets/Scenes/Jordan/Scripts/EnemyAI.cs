using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.Jordan.Scripts
{
    public class EnemyAI : Entity
    {
        protected Animator animator;
        
        protected bool isActive;
        
        protected int attackCount;
        
        [SerializeField] protected int maxActionRepetition = 2;
        [SerializeField] protected float distanceDetection = 10f;
        
        private State _currentState = State.Idle;

        private int _dodgeCount;
        
        private Transform _player;

        private Weapon _weapon;

        private enum State
        {
            Idle,
            Combat,
            Dead
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();

            _weapon = GetComponentInChildren<Weapon>();
            
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
        protected virtual void RandomAction()
        {
            var randomIndex = Random.Range(Variables.FirstActionIndex, Variables.NbActions);

            if (randomIndex == Variables.FirstActionIndex) Attack();
            else Dodge();
        }
        
        protected virtual void Attack()
        {
            UpdateCounters(true);
            
            isActive = true;
            
            animator.Play(Variables.AttackAnimName);
            
            _weapon.Shoot();
        }
        
        protected void Dodge()
        {
            UpdateCounters(false);
            
            isActive = true;
            
            animator.Play(Variables.DodgeAnimName);
        }
        
        protected virtual void EnemyActions()
        {
            if (isActive) return;
            
            if(_dodgeCount == maxActionRepetition) Attack();
            else if(attackCount == maxActionRepetition) Dodge();
            else RandomAction();
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
                _dodgeCount = Variables.ResetCounter;
                attackCount++;
            }
            else
            {
                attackCount = Variables.ResetCounter;
                _dodgeCount++;
            }
        }
        
        protected void ResetCounters()
        {
            _dodgeCount = Variables.ResetCounter;
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
    }
}