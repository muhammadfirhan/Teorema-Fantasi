using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErutaraDungeonUIHandler : MonoBehaviour
{
    public GameObject controllerObject;
    public GameObject pauseObject;

    private void Start()
    {
        Debug.Log("Player ID: " + PlayerTrack.playerInstance._playerID);
        Debug.Log("Character Name: " + PlayerTrack.playerInstance._characterName);
        Debug.Log("Character Gender: " + PlayerTrack.playerInstance._characterGender);
        Debug.Log("Quest ID: " + PlayerTrack.playerInstance._questID);
        Debug.Log("Mission ID: " + PlayerTrack.playerInstance._missionID);
        Debug.Log("World ID: " + PlayerTrack.playerInstance._worldID);
        Debug.Log("Energy: " + PlayerTrack.playerInstance._energy);
        Debug.Log("Profile ID: " + PlayerTrack.playerInstance._profileID);
    }

    public void showPause()
    {
        pauseObject.SetActive(true);
    }
}
