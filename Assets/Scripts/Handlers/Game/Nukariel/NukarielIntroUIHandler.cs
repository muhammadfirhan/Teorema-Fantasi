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

    public void ToNukarielCastle()
    {
        PlayerTrack.playerInstance._sceneID = 2;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toNukarielCastleOffset);
    }
}
