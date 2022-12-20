using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSettingsHandler : MonoBehaviour
{

    [SerializeField] private int toMainMenuOffset = 4;

    public void CancelChanges()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }

    public void AcceptChanges()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }
}
