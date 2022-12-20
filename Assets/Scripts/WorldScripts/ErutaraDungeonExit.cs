using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ErutaraDungeonExit : MonoBehaviour
{
    public PlayerController controller;

    [SerializeField] private bool buttonPressed;

    private void OnTriggerEnter(Collider other)
    {
        //buttonPressed = controller.buttonPressed;
        buttonPressed = true;
        if(buttonPressed == true)
        {
            SceneManager.LoadScene("Erutara_Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPressed = false;
    }
}
