using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTracking : MonoBehaviour
{
    public static PositionTracking positionInstance { get; private set; }
    public int _worldID;
    public int _sceneID;
    public float[] _position1 = new float[3];
    public float[] _position2 = new float[3];
    public float[] _position3 = new float[3];

    [SerializeField] private string objectID;

    private void Awake()
    {
        // Added object ID with name + object position to string
        objectID = name + transform.position.ToString();
    }

    private void Start()
    {
        // Create for loop for iterating all object of same type
        for (int i = 0; i < Object.FindObjectsOfType<PositionTracking>().Length; i++)
        {
            // If the object is not equal to this
            if (Object.FindObjectsOfType<PositionTracking>()[i] != this)
            {
                // If the object have the same ID, then destroy the new instance
                if (Object.FindObjectsOfType<PositionTracking>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        // Set profile instance to use in other scenes
        positionInstance = this;
        // Command to not destroy the object onload/switch scene
        DontDestroyOnLoad(gameObject);
    }   

    public void SetPosition(int worldID)
    {
        int inputID = worldID;
        if (inputID == 1)
        {
            _position1[0] = -31;
            _position1[1] = 1;
            _position1[2] = 30.5f;
            _position2[0] = 153;
            _position2[1] = 1;
            _position2[2] = 720;
            _position3[0] = 62;
            _position3[1] = 1;
            _position3[2] = 753;
        } 
        else if (inputID == 2)
        {
            _position1[0] = -6;
            _position1[1] = 1;
            _position1[2] = -23;
            _position2[0] = 119;
            _position2[1] = 1;
            _position2[2] = 457.5f;
            _position3[0] = 186;
            _position3[1] = 1;
            _position3[2] = 552;
        }
        else
        {
            Debug.Log("Invalid World ID");
            return;
        }
    }
}
