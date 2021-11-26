using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public float lerpSpeed;
    
    private GameObject _target;
    private Vector3 _freezedPos;
    private Vector3 _targetPosition;
    
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (PlayerManager.isCameraFreezed)
        {
            _targetPosition = new Vector3(PlayerManager.freezeCameraPos.x,PlayerManager.freezeCameraPos.y,0f)  + offset;
        }
        else
        { 
            _targetPosition = _target.transform.position + offset;
        }
        transform.position = Vector3.Lerp(transform.position, _targetPosition, lerpSpeed* Time.deltaTime);
    }
}