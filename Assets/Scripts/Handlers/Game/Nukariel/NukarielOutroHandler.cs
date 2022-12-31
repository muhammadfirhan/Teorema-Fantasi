using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NukarielOutroHandler : MonoBehaviour
{
    public GameObject outroObject;
    public GameObject pauseObject;

    private void Awake()
    {
        StartCoroutine(SetTimer());
    }

    public void ShowPause()
    {
        pauseObject.SetActive(true);
    }

    private void Update()
    {
        if (DurationData.durationInstance._second == 180)
        {
            Debug.Log("Waktu tersisa 3 menit lagi");
            Debug.Log("Mohon menyimpan");
        }
        else if (DurationData.durationInstance._second <= 0)
        {
            Debug.Log("Waktu habis");
            DurationData.durationInstance._second = 0;
            StopCoroutine(SetTimer());
            SceneManager.LoadScene("Main_Menu");
        }
    }

    IEnumerator SetTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            DurationData.durationInstance._second -= 1;
        }
    }

    public void ToResultScreen()
    {
        SceneManager.LoadScene("Result_Screen");
    }
}
