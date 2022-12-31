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
    public int _missionID;
    public int _worldID;
    public int _energy;
    public int _sceneID;
    public int _diffID;
    public float[] _position;
    public int _profileID;

    public PlayerData ()
    {
        _id = PlayerTrack.playerInstance._playerID;
        _characterName = PlayerTrack.playerInstance._characterName;
        _characterGender = PlayerTrack.playerInstance._characterGender;
        _questID = PlayerTrack.playerInstance._questID;
        _missionID = PlayerTrack.playerInstance._missionID;
        _worldID = PlayerTrack.playerInstance._worldID;
        _energy = PlayerTrack.playerInstance._energy;
        _sceneID = PlayerTrack.playerInstance._sceneID;
        _diffID = PlayerTrack.playerInstance._diffID;
        _profileID = PlayerTrack.playerInstance._profileID;

        GameObject playerObject = GameObject.FindWithTag("Player");
        Debug.Log("Pos X Saved Player: " + playerObject.transform.position.x);
        Debug.Log("Pos Y Saved Player: " + playerObject.transform.position.y);
        Debug.Log("Pos Z Saved Player: " + playerObject.transform.position.z);
        _position = new float[3];
        _position[0] = playerObject.transform.position.x;
        _position[1] = playerObject.transform.position.y;
        _position[2] = playerObject.transform.position.z;
    }

}
