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
    private GameObject playerObject;

    private Vector3 prevPos;
    private int eventID;

    public void UnPause()
    {
        pauseOverlay.SetActive(false);
    }

    public void SaveData()
    {
        if (SceneStateData._currentScene.Equals("Erutara_Intro"))
        {
            Debug.Log("You can't save here");
        }
        else if (SceneStateData._currentScene.Equals("Erutara_Outro"))
        {
            Debug.Log("You can't save here");
        }
        else if (SceneStateData._currentScene.Equals("Nukariel_Intro"))
        {
            Debug.Log("You can't save here");
        }
        else if (SceneStateData._currentScene.Equals("Nukariel_Outro"))
        {
            Debug.Log("You can't save here");
        }
        else
        {
            ToggleConfirmationWindow();
            SetConfirmationText("Yakin menyimpan?");
            yesButton.onClick.AddListener(delegate { SaveButtonEvent(); });
            noButton.onClick.AddListener(delegate { NoButtonEvent(); });
        }
    }

    public void ExitGame()
    {
        ToggleConfirmationWindow();
        SetConfirmationText("Yakin keluar? \nProses akan otomatis disimpan");
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

    public void SaveButtonEvent()
    {
        GetPlayerPos();
        SaveSystemPlayer.SavePlayer();
        //PlayerTrack.playerInstance.transform.position = prevPos;
        confirmationWindow.SetActive(false);
    }

    public void ExitButtonEvent()
    {
        if (SceneStateData._currentScene.Equals("Erutara_Intro"))
        {
            PlayerTrack.playerInstance._playerID = 0;
            PlayerTrack.playerInstance._characterName = "";
            PlayerTrack.playerInstance._characterGender = "";
            PlayerTrack.playerInstance._questID = 0;
            PlayerTrack.playerInstance._missionID = 0;
            PlayerTrack.playerInstance._worldID = 0;
            PlayerTrack.playerInstance._energy = 0;
            PlayerTrack.playerInstance._sceneID = 0;
            PlayerTrack.playerInstance._diffID = 0;
            PlayerTrack.playerInstance._profileID = 0;
            SceneManager.LoadScene("Main_Menu");
        }
        else if (SceneStateData._currentScene.Equals("Erutara_Outro"))
        {
            PlayerTrack.playerInstance._playerID = 0;
            PlayerTrack.playerInstance._characterName = "";
            PlayerTrack.playerInstance._characterGender = "";
            PlayerTrack.playerInstance._questID = 0;
            PlayerTrack.playerInstance._missionID = 0;
            PlayerTrack.playerInstance._worldID = 0;
            PlayerTrack.playerInstance._energy = 0;
            PlayerTrack.playerInstance._sceneID = 0;
            PlayerTrack.playerInstance._diffID = 0;
            PlayerTrack.playerInstance._profileID = 0;
            SceneManager.LoadScene("Main_Menu");
        }
        else if (SceneStateData._currentScene.Equals("Nukariel_Intro"))
        {
            PlayerTrack.playerInstance._playerID = 0;
            PlayerTrack.playerInstance._characterName = "";
            PlayerTrack.playerInstance._characterGender = "";
            PlayerTrack.playerInstance._questID = 0;
            PlayerTrack.playerInstance._missionID = 0;
            PlayerTrack.playerInstance._worldID = 0;
            PlayerTrack.playerInstance._energy = 0;
            PlayerTrack.playerInstance._sceneID = 0;
            PlayerTrack.playerInstance._diffID = 0;
            PlayerTrack.playerInstance._profileID = 0;
            SceneManager.LoadScene("Main_Menu");
        }
        else if (SceneStateData._currentScene.Equals("Nukariel_Outro"))
        {
            PlayerTrack.playerInstance._playerID = 0;
            PlayerTrack.playerInstance._characterName = "";
            PlayerTrack.playerInstance._characterGender = "";
            PlayerTrack.playerInstance._questID = 0;
            PlayerTrack.playerInstance._missionID = 0;
            PlayerTrack.playerInstance._worldID = 0;
            PlayerTrack.playerInstance._energy = 0;
            PlayerTrack.playerInstance._sceneID = 0;
            PlayerTrack.playerInstance._diffID = 0;
            PlayerTrack.playerInstance._profileID = 0;
            SceneManager.LoadScene("Main_Menu");
        }
        else
        {
            GetPlayerPos();
            SaveSystemPlayer.SavePlayer();
            //PlayerTrack.playerInstance.transform.position = prevPos;
            StartCoroutine(SaveTime());
        }
    }

    public void YesButtonEvent(int eventID)
    {
        if (eventID == 1)
        {
            GetPlayerPos();
            SaveSystemPlayer.SavePlayer();
            //PlayerTrack.playerInstance.transform.position = prevPos;
            confirmationWindow.SetActive(false);
        }
        else if (eventID == 2)
        {
            GetPlayerPos();
            SaveSystemPlayer.SavePlayer();
            //PlayerTrack.playerInstance.transform.position = prevPos;
            //PlayerTrack.playerInstance.objectID = name + prevPos;
            PlayerTrack.playerInstance._playerID = 0;
            PlayerTrack.playerInstance._characterName = "";
            PlayerTrack.playerInstance._characterGender = "";
            PlayerTrack.playerInstance._questID = 0;
            PlayerTrack.playerInstance._missionID = 0;
            PlayerTrack.playerInstance._worldID = 0;
            PlayerTrack.playerInstance._energy = 0;
            PlayerTrack.playerInstance._sceneID = 0;
            PlayerTrack.playerInstance._diffID = 0;
            PlayerTrack.playerInstance._profileID = 0;
            SceneManager.LoadScene("Main_Menu");
        }
    }

    public void NoButtonEvent()
    {
        confirmationWindow.SetActive(false);
    }

    private void GetPlayerPos()
    {
        playerObject = GameObject.FindWithTag("Player");
        //prevPos = PlayerTrack.playerInstance.transform.position;
        //PlayerTrack.playerInstance.transform.position = playerObject.transform.position;
        //PlayerTrack.playerInstance.objectID = name + playerObject.transform.position;
        playerObject = null;
    }

    IEnumerator SaveTime()
    {
        yield return new WaitForSeconds(2);
        PlayerTrack.playerInstance._playerID = 0;
        PlayerTrack.playerInstance._characterName = "";
        PlayerTrack.playerInstance._characterGender = "";
        PlayerTrack.playerInstance._questID = 0;
        PlayerTrack.playerInstance._missionID = 0;
        PlayerTrack.playerInstance._worldID = 0;
        PlayerTrack.playerInstance._energy = 0;
        PlayerTrack.playerInstance._sceneID = 0;
        PlayerTrack.playerInstance._diffID = 0;
        PlayerTrack.playerInstance._profileID = 0;
        SceneManager.LoadScene("Main_Menu");
    }
}
