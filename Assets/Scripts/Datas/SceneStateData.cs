using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateData : MonoBehaviour
{
    public static SceneStateData sceneInstance { get; private set; }
    public string _previousScene;
    public string _currentScene;

    [SerializeField] private string objectID;

    private void Awake()
    {
        // Added object ID with name + object position to string
        objectID = name + transform.position.ToString();
    }

    private void Start()
    {
        // Create for loop for iterating all object of same type
        for (int i = 0; i < Object.FindObjectsOfType<SceneStateData>().Length; i++)
        {
            // If the object is not equal to this
            if (Object.FindObjectsOfType<SceneStateData>()[i] != this)
            {
                // If the object have the same ID, then destroy the new instance
                if (Object.FindObjectsOfType<SceneStateData>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }
        // Set the current scene variable value
        _currentScene = gameObject.scene.name;
        // Set profile instance to use in other scenes
        sceneInstance = this;
        // Command to not destroy the object onload/switch scene
        DontDestroyOnLoad(gameObject);
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
