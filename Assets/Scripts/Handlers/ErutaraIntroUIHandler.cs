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

    public void showPause()
    {
        pauseObject.SetActive(true);
    }

    public void toErutaraDungeon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +  toErutaraDungeonOffset);
    }
}
