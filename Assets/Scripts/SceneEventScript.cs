
using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneEventScript : MonoBehaviour
{
    private UnityEvent _sceneEvent = new UnityEvent();
    public static int _sceneIndex;
    void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _sceneEvent.AddListener(SceneLoad);
        _sceneEvent.Invoke();
    }

    public void SceneLoad()
    {
        Debug.Log(_sceneIndex);
    }
}
