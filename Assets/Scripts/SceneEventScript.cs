using UnityEngine;
using UnityEngine.Events;

public class SceneEventScript : MonoBehaviour
{
    public UnityEvent _sceneEvent = new UnityEvent();
    void Start()
    {
        _sceneEvent.Invoke();
    }
}
