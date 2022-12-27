using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSettingsHandler : MonoBehaviour
{

    [SerializeField] private int toMainMenuOffset = 4;

    private void Start()
    {
        SceneStateData.sceneInstance.SetCurrent();
    }

    public void CancelChanges()
    {
        SceneStateData.sceneInstance.SetPrevious();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }

    public void AcceptChanges()
    {
        SceneStateData.sceneInstance.SetPrevious();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }
}
