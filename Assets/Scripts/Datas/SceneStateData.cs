using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateData : MonoBehaviour
{
    public static SceneStateData sceneData { get; private set; }
    public static  string _previousScene;
    public static string _currentScene;

    private void OnDestroy()
    {
        SetPrevious();
    }

    private void Start()
    {
        sceneData = this;
        Debug.Log("Previous Scene was: " + _previousScene);
        SetCurrent();
        Debug.Log("Current Scene is: " + _currentScene);
    }

    public void SetPrevious()
    {
        _previousScene = gameObject.scene.name;
    }

    public void SetCurrent()
    {
        _currentScene = gameObject.scene.name;
    }
}
