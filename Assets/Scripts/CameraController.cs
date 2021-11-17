using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public float lerpSpeed;
    
    private GameObject _target;
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (ActionAndInputSystem.isCameraFreezed)
        {
            Vector3 targetPosition = 
        }
        Vector3 targetPosition = _target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed* Time.deltaTime);
    }
}