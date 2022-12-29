using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErutaraDungeonUIHandler : MonoBehaviour
{
    public GameObject controllerObject;
    public GameObject pauseObject;
    public GameObject mapUI;
    public GameObject journalUI;
    public GameObject energyUI;

    private int energyLimit;
    private float waitAddEnergy = 60f;

    private void Start()
    {
        /*
        Debug.Log("Player ID: " + PlayerTrack.playerInstance._playerID);
        Debug.Log("Character Name: " + PlayerTrack.playerInstance._characterName);
        Debug.Log("Character Gender: " + PlayerTrack.playerInstance._characterGender);
        Debug.Log("Quest ID: " + PlayerTrack.playerInstance._questID);
        Debug.Log("Mission ID: " + PlayerTrack.playerInstance._missionID);
        Debug.Log("World ID: " + PlayerTrack.playerInstance._worldID);
        Debug.Log("Energy: " + PlayerTrack.playerInstance._energy);
        Debug.Log("Profile ID: " + PlayerTrack.playerInstance._profileID);
        */
        energyLimit = DifficultyData.difficultyInstance._energyLimit;
        if (PlayerTrack.playerInstance._missionID >= 2)
        {
            mapUI.SetActive(true);
            journalUI.SetActive(true);
            energyUI.SetActive(true);
            UpdateEnergy();
        }
    }

    public void TriggerEnergy()
    {
        if (PlayerTrack.playerInstance._missionID >= 2)
        {
            UpdateEnergy();
        }
    }

    public void ShowPause()
    {
        pauseObject.SetActive(true);
    }

    void UpdateEnergy()
    {
        TMP_Text energyText = energyUI.GetComponentInChildren<TMP_Text>();
        energyText.text = PlayerTrack.playerInstance._energy + "/" + energyLimit;
        StartCoroutine(AddEnergy(energyText));
    }

    IEnumerator AddEnergy(TMP_Text theText)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitAddEnergy);
            if (PlayerTrack.playerInstance._energy < energyLimit)
            {
                PlayerTrack.playerInstance._energy += 1;
                theText.text = PlayerTrack.playerInstance._energy + "/" + energyLimit;
            }
            else
            {
                theText.text = PlayerTrack.playerInstance._energy + "/" + energyLimit;
            }
        }
    }
}
