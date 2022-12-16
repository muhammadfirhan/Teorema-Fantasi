using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationData : MonoBehaviour
{
    public static DurationData durationInstance;

    public float _hour;
    public float _minute;
    public float _second;

    [SerializeField] private string objectID;

    private void Awake()
    {
        // Added object ID with name + object position to string
        objectID = name + transform.position.ToString();
    }

    private void Start()
    {
        // Create for loop for iterating all object of same type
        for (int i = 0; i < Object.FindObjectsOfType<DurationData>().Length; i++)
        {
            // If the object is not equal to this
            if (Object.FindObjectsOfType<DurationData>()[i] != this)
            {
                // If the object have the same ID, then destroy the new instance
                if (Object.FindObjectsOfType<DurationData>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        // Set player instance to use in other scenes
        durationInstance = this;
        // Command to not destroy the object onload/switch scene
        DontDestroyOnLoad(gameObject);
    }
}
