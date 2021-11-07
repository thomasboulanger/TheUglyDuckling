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

        private void Awake()
        {
            _playerRb = GameObject.FindGameObjectWithTag(Variables.PlayerTag).GetComponent<Rigidbody>();
        }
        
        private void FixedUpdate()
        {
            //_playerRb.velocity = new Vector3(10f, 0, 0);
            
            Parallax2D();
        }

        private void Parallax2D()
        {
            for (var currentLayer = 0; currentLayer < layers.Length; currentLayer++)
            {
                var currentLayerMaterial = layers[currentLayer].GetComponent<Image>().material;
                
                var offset = /*_playerRb.velocity.x */ (Time.time * (scrollSpeed[currentLayer] + globalScrollSpeed));
                
                currentLayerMaterial.SetTextureOffset(Variables.LayersTextureName, new Vector2(offset, 0));
            }
        }
    }
}