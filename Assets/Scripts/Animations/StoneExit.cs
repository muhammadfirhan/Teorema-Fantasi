using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneExit : MonoBehaviour
{
    public Animator anim;
    public GameObject stoneDoor;
    public PlayerController controller;

    [SerializeField] private int missionMinID;
    [SerializeField] private bool buttonPressed;

    private void Start()
    {
        missionMinID = stoneDoor.GetComponent<ErutaraDungeonStoneDoorLimit>().missionMinID;
    }

    private void OnTriggerEnter(Collider other)
    {
        //StartCoroutine("TouchButton");
        Debug.Log("Button Pressed? " + buttonPressed);
        buttonPressed = true;
        if (buttonPressed == true)
        {
            if (PlayerTrack.playerInstance._missionID >= missionMinID)
            {
                anim.SetBool("QuestCleared", true);
                anim.SetTrigger("PlayerProximity");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPressed = false;
        anim.SetBool("QuestCleared", false);
        anim.SetTrigger("PlayerProximity");
    }

    IEnumerator TouchButton()
    {
        yield return new WaitForSeconds(5);
        buttonPressed = controller.buttonPressed;
    }
}
