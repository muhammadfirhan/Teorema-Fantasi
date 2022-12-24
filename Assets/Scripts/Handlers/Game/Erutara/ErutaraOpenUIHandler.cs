using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErutaraOpenUIHandler : MonoBehaviour
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

    public void showPause()
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
