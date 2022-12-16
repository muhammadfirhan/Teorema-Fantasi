using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    public static PlayerProfile profileInstance { get; private set; }
    public int _profileID;
    public string _profileName;
    public int _profileAge;
    public string _profileGender;
    public int _profileCoin;
    public int _profilePoint;

    // Create object ID for multi instance
    [SerializeField] private string objectID;

    private void Awake()
    {
        // Added object ID with name + object position to string
        objectID = name + transform.position.ToString();
    }

    private void Start()
    {
        // Create for loop for iterating all object of same type
        for (int i = 0; i < Object.FindObjectsOfType<PlayerProfile>().Length; i++)
        {
            // If the object is not equal to this
            if (Object.FindObjectsOfType<PlayerProfile>()[i] != this)
            {
                // If the object have the same ID, then destroy the new instance
                if (Object.FindObjectsOfType<PlayerProfile>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        // Set profile instance to use in other scenes
        profileInstance = this;
        // Command to not destroy the object onload/switch scene
        DontDestroyOnLoad(gameObject);
    }
}
