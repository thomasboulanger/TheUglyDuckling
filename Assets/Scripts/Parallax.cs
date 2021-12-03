using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float globalScrollSpeed;
    [SerializeField] private float[] scrollSpeed;
        
    //[SerializeField] private GameObject[] layers;
    [SerializeField] private GameObject layers3D;

    private Rigidbody2D _playerRb;

    private void Awake()
    {
        _playerRb = GameObject.FindGameObjectWithTag(Variables.PlayerTag).GetComponent<Rigidbody2D>();
    }
        
    private void FixedUpdate()
    {
        //Parallax2D();
        Parallax3D();
    }

    /*private void Parallax2D()
    {
        for (var currentLayer = 0; currentLayer < layers.Length; currentLayer++)
        {
            var currentLayerMaterial = layers[currentLayer].GetComponent<Image>().material;
                
            var offset = _playerRb.velocity.x  (Time.time * (scrollSpeed[currentLayer] + globalScrollSpeed));
                
            currentLayerMaterial.SetTextureOffset(Variables.LayersTextureName, new Vector2(offset, 0));
        }
    }*/

    private void Parallax3D()
    {
        layers3D.transform.position -= new Vector3(globalScrollSpeed * _playerRb.velocity.x, 0, 0) ;
    }
}