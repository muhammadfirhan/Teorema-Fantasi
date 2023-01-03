using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StoneExit : MonoBehaviour
{
    public Animator anim;
    public PlayerController controller;
    public Button interactButton;

    [SerializeField] private int missionMinID = 2;
    [SerializeField] private bool buttonPressed;
    [SerializeField] private bool playerNear;

    private void Start()
    {
        playerNear = buttonPressed = false;
        interactButton.onClick.AddListener(delegate { ButtonClicked(); });
        StartCoroutine(SetButtonPressed());
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
                if (PlayerTrack.playerInstance._missionID >= missionMinID 
                    && PlayerTrack.playerInstance._questID >= 2)
                {
                    anim.SetBool("QuestCleared", true);
                    anim.SetTrigger("PlayerProximity");
                    ButtonUnClicked();
                    StopCoroutine("TouchButton");
                }
                else if (PlayerTrack.playerInstance._questID == 1)
                {
                    GameObject playerObject = GameObject.FindWithTag("Player");
                    PositionTracking.positionInstance._tempPos[0] =
                        playerObject.transform.position.x;
                    PositionTracking.positionInstance._tempPos[1] =
                        playerObject.transform.position.y;
                    PositionTracking.positionInstance._tempPos[2] =
                        playerObject.transform.position.z;
                    SceneManager.LoadScene("Puzzle_Type1");
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
