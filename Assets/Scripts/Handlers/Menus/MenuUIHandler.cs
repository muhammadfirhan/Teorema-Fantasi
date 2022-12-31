using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject selectSaveSlotObject;
    public TMP_Text profText1;
    public TMP_Text worldText1;
    public TMP_Text profText2;
    public TMP_Text worldText2;
    public TMP_Text profText3;
    public TMP_Text worldText3;
    public TMP_Text profText4;
    public TMP_Text worldText4;
    public TMP_Text profText5;
    public TMP_Text worldText5;

    private int toGameplaySelectionOffset = 1;
    private int toSelectSaveOffset = 2;
    private int toProfileOffset = 3;
    private int toSettingsOffset = 4;


    private void Start()
    {
        GetSaves();
        // Show profile info on debug console
        /*
        Debug.Log("Profile ID: " + PlayerProfile.profileInstance._profileID);
        Debug.Log("Profile Name: " + PlayerProfile.profileInstance._profileName);
        Debug.Log("Profile Age: " + PlayerProfile.profileInstance._profileAge);
        Debug.Log("Profile Gender: " + PlayerProfile.profileInstance._profileGender);
        Debug.Log("Profile Coin: " + PlayerProfile.profileInstance._profileCoin);
        Debug.Log("Profile Point: " + PlayerProfile.profileInstance._profilePoint);
        */
    }
    
    public void GoToGameplaySelection()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toGameplaySelectionOffset);
    }

    public void GoToSelectSave()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toSelectSaveOffset);
    }

    public void GoToProfile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toProfileOffset);
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toSettingsOffset);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SelectPlay()
    {
        selectSaveSlotObject.SetActive(true);
    }

    public void DeSelectPlay()
    {
        selectSaveSlotObject.SetActive(false);
    }

    public void SetText(PlayerData data, TMP_Text profText, TMP_Text worldText)
    {
        if (data != null)
        {
            profText.text = data._characterName;
            if (data._worldID == 1)
            {
                worldText.text = "Erutara";
            }
            else if (data._worldID == 2)
            {
                worldText.text = "Nukariel";
            }
        }
        else
        {
            profText.text = "Nama Karakter";
            worldText.text = "Dunia";
        }
    }

    public void GetSaves()
    {
        PlayerData data1 = SaveSystemPlayer.LoadPlayer(1);
        PlayerData data2 = SaveSystemPlayer.LoadPlayer(2);
        PlayerData data3 = SaveSystemPlayer.LoadPlayer(3);
        PlayerData data4 = SaveSystemPlayer.LoadPlayer(4);
        PlayerData data5 = SaveSystemPlayer.LoadPlayer(5);

        SetText(data1, profText1, worldText1);
        SetText(data2, profText2, worldText2);
        SetText(data3, profText3, worldText3);
        SetText(data4, profText4, worldText4);
        SetText(data5, profText5, worldText5);
    }

    public void SelectSave1()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(1);

        if (data != null)
        {
            SaveSystemPlayer.DeleteSave(1);
            PlayerTrack.playerInstance._playerID = 1;
            GoToGameplaySelection();
        }
        else
        {
            PlayerTrack.playerInstance._playerID = 1;
            GoToGameplaySelection();
        }
    }

    public void SelectSave2()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(2);

        if (data != null)
        {
            SaveSystemPlayer.DeleteSave(2);
            PlayerTrack.playerInstance._playerID = 2;
            GoToGameplaySelection();
        }
        else
        {
            PlayerTrack.playerInstance._playerID = 2;
            GoToGameplaySelection();
        }
    }

    public void SelectSave3()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(3);

        if (data != null)
        {
            SaveSystemPlayer.DeleteSave(3);
            PlayerTrack.playerInstance._playerID = 3;
            GoToGameplaySelection();
        }
        else
        {
            PlayerTrack.playerInstance._playerID = 3;
            GoToGameplaySelection();
        }
    }

    public void SelectSave4()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(4);

        if (data != null)
        {
            SaveSystemPlayer.DeleteSave(4);
            PlayerTrack.playerInstance._playerID = 4;
            GoToGameplaySelection();
        }
        else
        {
            PlayerTrack.playerInstance._playerID = 4;
            GoToGameplaySelection();
        }
    }

    public void SelectSave5()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(5);

        if (data != null)
        {
            SaveSystemPlayer.DeleteSave(5);
            PlayerTrack.playerInstance._playerID = 5;
            GoToGameplaySelection();
        }
        else
        {
            PlayerTrack.playerInstance._playerID = 5;
            GoToGameplaySelection();
        }
    }
}
