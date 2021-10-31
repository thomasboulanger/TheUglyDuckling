using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Jordan.Scripts
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private float globalScrollSpeed;
        [SerializeField] private float[] scrollSpeed;
        
        [SerializeField] private GameObject[] layers;
        
        private Rigidbody _playerRb;
        
        //See If Parallax depends on player velocity
        private void Awake()
        {
            _playerRb = GameObject.FindGameObjectWithTag(Variables.PlayerTag).GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            //_playerRb.velocity = new Vector3(1f, 0, 0);
            
            for (var currentLayer = 0; currentLayer < layers.Length; currentLayer++)
            {
                var currentLayerMaterial = layers[currentLayer].GetComponent<Image>().material;
                
                var offset = _playerRb.velocity.x * (Time.time * (scrollSpeed[currentLayer] + globalScrollSpeed));
                
                currentLayerMaterial.SetTextureOffset(Variables.LayersTextureName, new Vector2(offset, 0));
            }
        }
    }
}