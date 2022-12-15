using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int _id;
    public string _characterName;
    public string _characterGender;
    public int _questID;
    public int _worldID;
    public int _energy;
    public float[] _position;
    public int _profileID;

    public PlayerData ()
    {
        _id = PlayerTrack.playerInstance._playerID;
        _characterName = PlayerTrack.playerInstance._characterName;
        _characterGender = PlayerTrack.playerInstance._characterGender;
        _questID = PlayerTrack.playerInstance._questID;
        _worldID = PlayerTrack.playerInstance._worldID;
        _energy = PlayerTrack.playerInstance._energy;
        _profileID = PlayerTrack.playerInstance._profileID;
        
        _position = new float[3];
        _position[0] = PlayerTrack.playerInstance.transform.position.x;
        _position[1] = PlayerTrack.playerInstance.transform.position.y;
        _position[2] = PlayerTrack.playerInstance.transform.position.z;
    }

}
