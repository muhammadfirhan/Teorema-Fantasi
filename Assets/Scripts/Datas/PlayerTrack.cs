using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrack : MonoBehaviour
{
    public static PlayerTrack playerInstance { get; private set; }
    public int _playerID;
    public string _characterName;
    public string _characterGender;
    public int _questID;
    public int _missionID;
    public int _worldID;
    public int _energy;
    public int _sceneID;
    public int _profileID;

    [SerializeField] private string objectID;

    private void Awake()
    {
        // Added object ID with name + object position to string
        objectID = name + transform.position.ToString();
    }

    private void Start()
    {
        // Create for loop for iterating all object of same type
        for (int i = 0; i < Object.FindObjectsOfType<PlayerTrack>().Length; i++)
        {
            // If the object is not equal to this
            if (Object.FindObjectsOfType<PlayerTrack>()[i] != this)
            {
                // If the object have the same ID, then destroy the new instance
                if (Object.FindObjectsOfType<PlayerTrack>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        // Set player instance to use in other scenes
        playerInstance = this;
        // Command to not destroy the object onload/switch scene
        DontDestroyOnLoad(gameObject);
    }
}
