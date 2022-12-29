using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ErutaraIntroUIHandler : MonoBehaviour
{
    [SerializeField] private int toErutaraDungeonOffset = 1;

    public GameObject introObject;
    public GameObject pauseObject;

    private void Start()
    {
        SceneStateData.sceneInstance.SetCurrent();
    }

    public void ShowPause()
    {
        pauseObject.SetActive(true);
    }

    public void ToErutaraDungeon()
    {
        SceneStateData.sceneInstance.SetPrevious();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +  toErutaraDungeonOffset);
    }
}
