using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ErutaraHallEnter : MonoBehaviour
{
    public PlayerController controller;
    public Button interactButton;

    [SerializeField] private bool buttonPressed;
    [SerializeField] private bool playerNear;

    private void Start()
    {
        buttonPressed = playerNear = false;
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
                if (PlayerTrack.playerInstance._missionID >= 2)
                {
                    StopCoroutine("TouchButton");
                    PlayerTrack.playerInstance._sceneID = 4;

                    SceneManager.LoadScene("Erutara_Hall");
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
