using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplaySelectionHandler : MonoBehaviour
{
    [SerializeField] private int toMainMenuOffset = 1;

    public void backToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }
}
