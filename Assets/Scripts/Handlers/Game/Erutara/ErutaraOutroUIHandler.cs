using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ErutaraOutroUIHandler : MonoBehaviour
{
    public GameObject outroObject;
    public GameObject pauseObject;

    public void ShowPause()
    {
        pauseObject.SetActive(true);
    }

    public void ToResultScreen()
    {
        SceneManager.LoadScene("Result_Screen");
    }
}
