using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyData : MonoBehaviour
{
    public static DifficultyData difficultyInstance;

    public int _diffID;
    public int _questID;
    public int _missionID;
    public int _energyLimit;

    [SerializeField] private string objectID;

    private void Awake()
    {
        // Added object ID with name + object position to string
        objectID = name + transform.position.ToString();
    }

    private void Start()
    {
        // Create for loop for iterating all object of same type
        for (int i = 0; i < Object.FindObjectsOfType<DifficultyData>().Length; i++)
        {
            // If the object is not equal to this
            if (Object.FindObjectsOfType<DifficultyData>()[i] != this)
            {
                // If the object have the same ID, then destroy the new instance
                if (Object.FindObjectsOfType<DifficultyData>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        // Set player instance to use in other scenes
        difficultyInstance = this;
        // Command to not destroy the object onload/switch scene
        DontDestroyOnLoad(gameObject);
    }
}
