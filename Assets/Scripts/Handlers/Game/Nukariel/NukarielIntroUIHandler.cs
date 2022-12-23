using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NukarielIntroUIHandler : MonoBehaviour
{
    [SerializeField] private int toNukarielCastleOffset = 1;

    public GameObject introObject;
    public GameObject pauseObject;

    public void ShowPause()
    {
        pauseObject.SetActive(true);
    }

    public void ToNukarielCastle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toNukarielCastleOffset);
    }
}
