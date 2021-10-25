using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class Projectile : MonoBehaviour
    {
        private Entity _entity;

        private bool _isPlayer;

        private void Awake()
        {
            _entity = GetComponentInParent<Entity>();

            DetectIfPlayerIsEntity();
        }

        private void DetectIfPlayerIsEntity() => _isPlayer = _entity.CompareTag(Variables.PlayerTag);

        private void OnTriggerEnter(Collider other)
        {
            if(!_isPlayer && other.CompareTag(Variables.PlayerTag)) 
                other.GetComponent<Entity>().TakeDamage(_entity);
            else if (_isPlayer && other.CompareTag(Variables.EnemyTag)) 
                other.GetComponent<Entity>().TakeDamage(_entity);
        }
    }
}