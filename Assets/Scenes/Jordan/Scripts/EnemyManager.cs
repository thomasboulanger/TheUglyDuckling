using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.Jordan.Scripts
{
    public class EnemyManager : Entity
    {
        protected Animator Animator;
        
        protected bool IsActive;
        
        private State _currentState = State.Idle;

        private int _dodgeCount;
        private int _attackCount;

        private Entity _player;
        
        [Space(20)]
        [SerializeField] private int maxActionRepetition = 2;
        [SerializeField] private float distanceDetection = 10f;
        
        private enum State
        {
            Idle,
            Combat,
            Dead
        }

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            _player = GameObject.FindGameObjectWithTag(Variables.PlayerTag).GetComponent<Entity>();
            
            ResetCounters();
        }

        private void Update()
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
            _currentState = PlayerDetected();
            if (IsDead) _currentState = State.Dead;
        }
        
        private void Combat()
        {
            EnemyActions();
            
            _currentState = PlayerDetected();
            if (IsDead) _currentState = State.Dead;
        }

        private void Dead()
        {
            Animator.Play(Variables.DeadAnimName);
        }
        #endregion
        
        #region Actions
        protected virtual void RandomAction()
        {
            var randomIndex = Random.Range(Variables.FirstActionIndex, Variables.NumberOfActions);

            if (randomIndex == Variables.FirstActionIndex) Attack();
            else Dodge();
        }
        
        private void EnemyActions()
        {
            if (IsActive) return;
            
            if(_dodgeCount == maxActionRepetition) Attack();
            else if(_attackCount == maxActionRepetition) Dodge();
            else RandomAction();
        }
        
        protected virtual void Attack()
        {
            UpdateCounters(true);
            
            IsActive = true;
            
            Animator.Play(Variables.AttackAnimName);
        }
        
        protected void Dodge()
        {
            UpdateCounters(false);
            
            IsActive = true;
            
            Animator.Play(Variables.DodgeAnimName);
        }
        #endregion

        #region AnimationEvent
        [UsedImplicitly] private void EndAnimation() => IsActive = false;
        [UsedImplicitly] private void DestroyWhenDead() => Destroy(gameObject);
        #endregion
        
        private State PlayerDetected()
        {
            var playerPosition = _player.transform.position;
            var enemyPosition = transform.position;

            return Vector3.Distance(playerPosition, enemyPosition) < distanceDetection ? State.Combat : State.Idle;
        }

        #region Counters
        protected void UpdateCounters(bool isAttack)
        {
            if (isAttack)
            {
                _dodgeCount = Variables.ResetCounter;
                _attackCount++;
            }
            else
            {
                _attackCount = Variables.ResetCounter;
                _dodgeCount++;
            }
        }
        
        private void ResetCounters()
        {
            _dodgeCount = Variables.ResetCounter;
            _attackCount = Variables.ResetCounter;
        }
        #endregion
    }
}