using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalFirst : MonoBehaviour
{
    public Animator anim;
    public GameObject journalObject;
    public PlayerController controller;
    public Button interactButton;
    public GameObject mapUI;
    public GameObject journalUI;
    public GameObject energyUI;
    public GameObject canvasUI;

    [SerializeField] private int missionID;
    [SerializeField] private bool buttonPressed;
    [SerializeField] private bool playerNear;
    private readonly int journalMissionID = 2;

    private void Start()
    {
        playerNear = buttonPressed = false;
        missionID = journalMissionID;
        if (PlayerTrack.playerInstance._missionID >= missionID)
        {
            journalObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            interactButton.onClick.AddListener(delegate { ButtonClicked(); });
            StartCoroutine(SetButtonPressed());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerNear = true;
        StartCoroutine("TouchButton");
    }

    private void OnTriggerExit(Collider other)
    {
        playerNear = buttonPressed = false;
        anim.SetBool("QuestCleared", false);
        anim.SetTrigger("PlayerProximity");
    }

    void ButtonClicked()
    {
        buttonPressed = true;
    }

    void ButtonUnClicked()
    {
        buttonPressed = false;
    }

    IEnumerator TouchButton()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (buttonPressed && playerNear)
            {
                if (PlayerTrack.playerInstance._missionID < missionID)
                {
                    PlayerTrack.playerInstance._missionID += 1;
                    PlayerTrack.playerInstance._questID += 1;
                    canvasUI.GetComponent<ErutaraDungeonUIHandler>().TriggerEnergy();
                    anim.SetBool("QuestCleared", true);
                    anim.SetTrigger("PlayerProximity");
                    mapUI.SetActive(true);
                    journalUI.SetActive(true);
                    energyUI.SetActive(true);
                    journalObject.SetActive(false);
                    ButtonUnClicked();
                    StopCoroutine("TouchButton");
                }
            }
        }
    }

    IEnumerator SetButtonPressed()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            ButtonUnClicked();
        }
    }

}
