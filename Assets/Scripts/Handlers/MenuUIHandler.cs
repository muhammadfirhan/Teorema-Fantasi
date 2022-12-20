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
    private int toGameplaySelectionOffset = 1;
    private int toSelectSaveOffset = 2;
    private int toProfileOffset = 3;
    private int toSettingsOffset = 4;


    private void Start()
    {
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
}
