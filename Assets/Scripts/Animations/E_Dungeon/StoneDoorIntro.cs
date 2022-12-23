using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoneDoorIntro : MonoBehaviour
{
    public Animator anim;
    public GameObject stoneDoor;
    public PlayerController controller;
    public Button interactButton;

    [SerializeField] private int missionMinID;
    [SerializeField] private bool buttonPressed;

    private void Start()
    {
        missionMinID = stoneDoor.GetComponent<ErutaraDungeonStoneDoorIntro>().missionMinID;
        interactButton.onClick.AddListener(delegate { ButtonClicked(); });
        StartCoroutine(SetButtonPressed());
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("TouchButton");
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPressed = false;
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
            if (buttonPressed == true)
            {
                if (PlayerTrack.playerInstance._missionID >= missionMinID)
                {
                    anim.SetBool("QuestCleared", true);
                    anim.SetTrigger("PlayerProximity");
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
