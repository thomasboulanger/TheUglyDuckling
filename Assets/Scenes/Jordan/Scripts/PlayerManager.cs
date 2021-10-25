using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class PlayerManager : Entity
    {
        //temp damage enemy
        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Damage(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Entity>());

            //TODO : anim + box collider
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag(Variables.EnemyTag)) Damage(other.gameObject.GetComponent<Entity>());
        }
    }
}