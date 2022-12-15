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
    public GameObject popupFail;
    //public GameObject profileObject;

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
        TMP_Text notifText = popupFail.GetComponentInChildren<TMP_Text>();
        if (pName.Equals(""))
        {
            popupFail.SetActive(true);
            notifText.text = "Nama tidak boleh kosong";
            nameField.text = "";
            ageField.text = "";
        }
        else if (pName.Length >= 4)
        {
            if (pAge < 7)
            {
                popupFail.SetActive(true);
                notifText.text = "Umur terlalu muda";
                nameField.text = "";
                ageField.text = "";
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

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
