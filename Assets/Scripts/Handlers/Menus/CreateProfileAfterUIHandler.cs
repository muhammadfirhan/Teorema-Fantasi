using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreateProfileAfterUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField ageField;
    public TMP_Dropdown genderField;
    public GameObject notifObject;

    [SerializeField] private int toMainMenuOffset = 7;
    private float notifTimer = 5.0f;

    public void CreateProfile()
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
            notifObject.SetActive(true);
            notifText.text = "Nama tidak boleh kosong atau kurang dari 3 huruf";
            nameField.text = "";
            StartCoroutine(SpawnNotif());
        }
        else if (pName.Length >= 3)
        {
            if (pAge < 7)
            {
                notifObject.SetActive(true);
                notifText.text = "Umur kurang dari 7";
                ageField.text = "";
                StartCoroutine(SpawnNotif());
            }
            else if (pAge >= 7)
            {
                //profileObject.SetActive(true);
                PlayerProfile.profileInstance._profileName = pName;
                PlayerProfile.profileInstance._profileAge = pAge;
                PlayerProfile.profileInstance._profileGender = pGender;
                PlayerProfile.profileInstance._profileCoin = 0;
                PlayerProfile.profileInstance._profilePoint = 0;
                SaveSystemProfile.SaveProfile();

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
            }
        }
    }

    IEnumerator SpawnNotif()
    {
        yield return new WaitForSeconds(notifTimer);
        notifObject.SetActive(false);
    }
}
