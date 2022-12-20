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

    [SerializeField] private int toMainMenuOffset = 3;

    private void Start()
    {
        profileNameText.text = "Nama: " + PlayerProfile.profileInstance._profileName;
        profileAgeText.text = "Umur: " + PlayerProfile.profileInstance._profileAge;
        profileGenderText.text = "Gender: " + PlayerProfile.profileInstance._profileGender;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }
}
