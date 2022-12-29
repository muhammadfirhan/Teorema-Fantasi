using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreateProfileUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField ageField;
    public TMP_Dropdown genderField;
    //public GameObject popupFail;
    public GameObject notifObject;
    //public GameObject profileObject;

    [SerializeField] private int toSelectProfileOffset = 9;
    private float notifTimer = 5.0f;

    private void Start()
    {
        CheckProfile();
    }
    public void Create_Profile()
    {
        // Get the transform component from the dropdown
        var dropdown = genderField.transform.GetComponent<TMP_Dropdown>();
        // Get the index of selected option
        int index = dropdown.value;
        // List all the options from the dropdown
        List<TMP_Dropdown.OptionData> menuOptions = dropdown.options;
        string pName = nameField.text.ToString();
        int.TryParse(ageField.text.ToString(), out int y);
        int pAge = y;
        string pGender = menuOptions[index].text.ToString();
        TMP_Text notifText = notifObject.GetComponentInChildren<TMP_Text>();
        if (pName.Equals("") || pName.Length < 3)
        {
            //popupFail.SetActive(true);
            notifObject.SetActive(true);
            notifText.text = "Nama tidak boleh kosong atau kurang dari 3 huruf";
            nameField.text = "";
            StartCoroutine(SpawnNotif());
        }
        else if (pName.Length >= 3)
        {
            if (pAge < 7)
            {
                //popupFail.SetActive(true);
                notifObject.SetActive(true);
                notifText.text = "Umur kurang dari 7";
                ageField.text = "";
                StartCoroutine(SpawnNotif());
            }
            else if (pAge >= 7)
            {
                //profileObject.SetActive(true);
                PlayerProfile.profileInstance._profileID = 1;
                PlayerProfile.profileInstance._profileName = pName;
                PlayerProfile.profileInstance._profileAge = pAge;
                PlayerProfile.profileInstance._profileGender = pGender;
                PlayerProfile.profileInstance._profileCoin = 0;
                PlayerProfile.profileInstance._profilePoint = 0;
                SaveSystemProfile.SaveProfile();
                SceneStateData.sceneInstance.SetPrevious();

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void CheckProfile()
    {
        int profileNum = SaveSystemProfile.CountProfiles();
        if(profileNum >= 1)
        {
            Debug.Log("Profile Detected");
            SceneStateData.sceneInstance.SetPrevious();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toSelectProfileOffset);
        }
        else
        {
            Debug.Log("No Profile Detected");
        }
    }

    IEnumerator SpawnNotif()
    {
        yield return new WaitForSeconds(notifTimer);
        notifObject.SetActive(false);
    }
}
