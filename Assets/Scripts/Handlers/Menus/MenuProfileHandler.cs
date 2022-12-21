using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuProfileHandler : MonoBehaviour
{
    public TMP_Text profileNameText;
    public TMP_Text profileAgeText;
    public TMP_Text profileGenderText;
    public TMP_Text profileCoinText;
    public TMP_InputField nameField;
    public TMP_InputField ageField;
    public TMP_Dropdown genderField;
    public GameObject notifObject;

    [SerializeField] private int toShopOffset = 2;
    [SerializeField] private int toMainMenuOffset = 3;
    [SerializeField] private int toHighScoreOffset = 3;
    [SerializeField] private int toSelectProfileOffset = 5;
    [SerializeField] private int toDeleteProfileOffset = 6;
    private float notifTimer = 5.0f;

    private void Start()
    {
        SetStart();
        SetCoin();
    }

    public void SetStart()
    {
        profileNameText.text = "Nama " + PlayerProfile.profileInstance._profileName;
        profileAgeText.text = "Umur " + PlayerProfile.profileInstance._profileAge;
        profileGenderText.text = "" + PlayerProfile.profileInstance._profileGender;
    }

    public void SetCoin()
    {
        profileCoinText.text = "" + PlayerProfile.profileInstance._profileCoin;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }

    public void ToShop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toShopOffset);
    }

    public void ToHighScore()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toHighScoreOffset);
    }

    public void ToSelectProfile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toSelectProfileOffset);
    }

    public void ToDeleteProfile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + toDeleteProfileOffset);
    }

    public void UpdateProfile()
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
            notifText.text = "Nama tidak boleh kosong atau kurang dari 3 huruf";
            nameField.text = "";
            StartCoroutine(SelectNotif());
        }
        else if (pName.Length >= 3)
        {
            if (pAge < 7)
            {
                notifText.text = "Umur kurang dari 7";
                ageField.text = "";
                StartCoroutine(SelectNotif());
            }
            else if (pAge >= 7)
            {
                PlayerProfile.profileInstance._profileName = pName;
                PlayerProfile.profileInstance._profileAge = pAge;
                PlayerProfile.profileInstance._profileGender = pGender;
                SaveSystemProfile.SaveProfile();

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
            }
        }
    }

    IEnumerator SelectNotif()
    {
        yield return new WaitForSeconds(notifTimer);
        TMP_Text notifText = notifObject.GetComponentInChildren<TMP_Text>();
        notifText.text = "Perbarui Profil";
    }
}
