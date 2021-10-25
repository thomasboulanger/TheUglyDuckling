using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class Projectile : MonoBehaviour
    {
        private Entity _entity;

        private void Awake()
        {
            _entity = GetComponentInParent<Entity>();
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(Variables.PlayerTag)) other.GetComponent<Entity>().Damage(_entity);
        }*/
    }
}