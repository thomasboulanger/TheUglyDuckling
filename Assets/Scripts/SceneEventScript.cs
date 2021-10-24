using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SceneEventScript : MonoBehaviour
{
    public UnityEvent sceneEvent = new UnityEvent();
    private BeatManager _beatManager;
    void Start()
    {
        _beatManager = GameObject.Find("GameManager").GetComponent<BeatManager>(); 
        sceneEvent.AddListener(_beatManager.GetSceneIndex);
        sceneEvent.Invoke();
    }
}
