using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIHandler : MonoBehaviour
{
    
    public GameObject pauseOverlay;
    public GameObject popupNotif;
    public GameObject confirmationWindow;
    public Button yesButton;
    public Button noButton;

    private int eventID;

    public void UnPause()
    {
        pauseOverlay.gameObject.SetActive(false);
    }

    public void SaveData()
    {
        eventID = 1;
        ToggleConfirmationWindow();
        SetConfirmationText("Yakin menyimpan?");
        yesButton.onClick.AddListener(delegate { YesButtonEvent(eventID); });
        noButton.onClick.AddListener(delegate { NoButtonEvent(); });
    }

    public void ExitGame()
    {
        eventID = 2;
        ToggleConfirmationWindow();
        SetConfirmationText("Yakin keluar? \nSimpan proses sebelum keluar");
        yesButton.onClick.AddListener(delegate { YesButtonEvent(eventID); });
        noButton.onClick.AddListener(delegate { NoButtonEvent(); });
    }

    public void ToggleConfirmationWindow()
    {
        confirmationWindow.SetActive(true);
    }

    public void SetConfirmationText(string text)
    {
        TMP_Text confirmText = confirmationWindow.GetComponentInChildren<TMP_Text>();
        confirmText.text = text;
    }

    public void YesButtonEvent(int eventID)
    {
        if (eventID == 1)
        {
            SaveSystemPlayer.SavePlayer();
            confirmationWindow.SetActive(false);
        }
        else if (eventID == 2)
        {
            PlayerTrack.playerInstance._playerID = 0;
            PlayerTrack.playerInstance._characterName = "";
            PlayerTrack.playerInstance._characterGender = "";
            PlayerTrack.playerInstance._questID = 0;
            PlayerTrack.playerInstance._missionID = 0;
            PlayerTrack.playerInstance._worldID = 0;
            PlayerTrack.playerInstance._energy = 0;
            PlayerTrack.playerInstance._profileID = 0;

            SceneManager.LoadScene("Main_Menu");
        }
    }

    public void NoButtonEvent()
    {
        confirmationWindow.SetActive(false);
    }
}
