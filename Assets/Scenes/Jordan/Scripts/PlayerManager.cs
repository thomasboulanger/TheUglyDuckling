using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class PlayerManager : Entity
    {
        //temp damage enemy
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space)) Damage(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Entity>());
        }
    }
}