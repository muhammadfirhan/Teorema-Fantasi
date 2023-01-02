using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PuzzleUIHandler : MonoBehaviour
{
    public GameObject pauseOverlay;
    public GameObject popupNotif;
    public GameObject confirmationWindow;
    public Button yesButton;
    public Button noButton;

    public void UnPause()
    {
        pauseOverlay.SetActive(false);
    }

    public void QuitPuzzle()
    {
        ToggleConfirmationWindow();
        SetConfirmationText("Berhenti dari teka-teki?");
        yesButton.onClick.AddListener(delegate { ExitButtonEvent(); });
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

    public void NoButtonEvent()
    {
        confirmationWindow.SetActive(false);
    }

    public void ExitButtonEvent()
    {
        if (DifficultyData.difficultyInstance._diffID == 1)
        {
            if (PlayerTrack.playerInstance._worldID == 1)
            {
                if (PlayerTrack.playerInstance._sceneID == 2)
                {
                    PlayerTrack.playerInstance._energy -= 3;
                    SceneManager.LoadScene("Erutara_Dungeon");
                } 
                else if (PlayerTrack.playerInstance._sceneID == 5)
                {
                    PlayerTrack.playerInstance._energy -= 3;
                    SceneManager.LoadScene("Erutara_Library");
                }
            }
            else if (PlayerTrack.playerInstance._worldID == 2)
            {
                if (PlayerTrack.playerInstance._sceneID == 2)
                {
                    PlayerTrack.playerInstance._energy -= 3;
                    SceneManager.LoadScene("Nukariel_Castle");
                }
                else if (PlayerTrack.playerInstance._sceneID == 5)
                {
                    PlayerTrack.playerInstance._energy -= 3;
                    SceneManager.LoadScene("Nukariel_Cave");
                }
            }
        }
        else if (DifficultyData.difficultyInstance._diffID == 2)
        {
            if (PlayerTrack.playerInstance._worldID == 1)
            {
                if (PlayerTrack.playerInstance._sceneID == 2)
                {
                    PlayerTrack.playerInstance._energy -= 7;
                    SceneManager.LoadScene("Erutara_Dungeon");
                }
                else if (PlayerTrack.playerInstance._sceneID == 5)
                {
                    PlayerTrack.playerInstance._energy -= 7;
                    SceneManager.LoadScene("Erutara_Library");
                }
            }
            else if (PlayerTrack.playerInstance._worldID == 2)
            {
                if (PlayerTrack.playerInstance._sceneID == 2)
                {
                    PlayerTrack.playerInstance._energy -= 7;
                    SceneManager.LoadScene("Nukariel_Castle");
                }
                else if (PlayerTrack.playerInstance._sceneID == 5)
                {
                    PlayerTrack.playerInstance._energy -= 7;
                    SceneManager.LoadScene("Nukariel_Cave");
                }
            }
        }
        else if (DifficultyData.difficultyInstance._diffID == 3)
        {
            if (PlayerTrack.playerInstance._worldID == 1)
            {
                if (PlayerTrack.playerInstance._sceneID == 2)
                {
                    PlayerTrack.playerInstance._energy -= 14;
                    SceneManager.LoadScene("Erutara_Dungeon");
                }
                else if (PlayerTrack.playerInstance._sceneID == 5)
                {
                    PlayerTrack.playerInstance._energy -= 14;
                    SceneManager.LoadScene("Erutara_Library");
                }
            }
            else if (PlayerTrack.playerInstance._worldID == 2)
            {
                if (PlayerTrack.playerInstance._sceneID == 2)
                {
                    PlayerTrack.playerInstance._energy -= 14;
                    SceneManager.LoadScene("Nukariel_Castle");
                }
                else if (PlayerTrack.playerInstance._sceneID == 5)
                {
                    PlayerTrack.playerInstance._energy -= 14;
                    SceneManager.LoadScene("Nukariel_Cave");
                }
            }
        }
    }
}
