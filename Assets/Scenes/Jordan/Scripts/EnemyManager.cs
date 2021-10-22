using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.Jordan.Scripts
{
    public class EnemyManager : Entity
    {
        private State _currentState = State.Idle;
        
        private bool _isActive;

        private int _dodgeCount;
        private int _attackCount;
        
        private Entity _player;
        
        [Space(20)]
        [SerializeField] private int maxActionRepetition = 2;
        [SerializeField] private float distanceDetection = 10f;
        
        private enum State
        {
            Idle,
            Combat
        }

        private void Awake()
        {
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
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        #region States
        private void Idle()
        {
            if (PlayerDetected()) _currentState = State.Combat;
        }
        
        private void Combat()
        {
            EnemyActions();
            
            if (!PlayerDetected()) _currentState = State.Idle;
        }
        #endregion
        
        #region Actions
        private void EnemyActions()
        {
            if (_isActive) return;
            
            if(_dodgeCount == maxActionRepetition) Attack();
            else if(_attackCount == maxActionRepetition) Dodge();
            else
            {
                var randomIndex = Random.Range(Variables.FirstActionIndex, Variables.NumberOfActions);

                if (randomIndex == Variables.FirstActionIndex) Attack();
                else Dodge();
            }
        }
        
        private void Attack()
        {
            UpdateCounters(true);
            
            //Todo : animation
            Damage(_player);
            
            //_isActive = true;
            
            //TODO : OnAnimationEnd isActive false
        }
        
        private void Dodge()
        {
            UpdateCounters(false);
            
            //Todo : animation et esquive
            //_isActive = true;
            
            //TODO : OnAnimationEnd isactive false
        }
        #endregion
        
        private bool PlayerDetected()
        {
            var playerPosition = _player.transform.position;
            var enemyPosition = transform.position;

            return Vector3.Distance(playerPosition, enemyPosition) < distanceDetection;
        }

        #region Counters
        private void ResetCounters()
        {
            _dodgeCount = Variables.ResetCounter;
            _attackCount = Variables.ResetCounter;
        }

        private void UpdateCounters(bool isAttack)
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
        #endregion
    }
}