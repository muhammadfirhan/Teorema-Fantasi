using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NukarielHutExit : MonoBehaviour
{
    public PlayerController controller;
    public Button interactButton;

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
            if (buttonPressed && PlayerTrack.playerInstance._missionID >= 4 && playerNear)
            {
                StopCoroutine("TouchButton");
                PlayerTrack.playerInstance._sceneID = 3;

                SceneManager.LoadScene("Nukariel_Forest");
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
