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

    private void Start()
    {
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
                StopCoroutine("TouchButton");
                SceneManager.LoadScene("Erutara_Hall");
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
