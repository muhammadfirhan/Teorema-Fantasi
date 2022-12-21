using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplaySelectionHandler : MonoBehaviour
{
    [SerializeField] private int toMainMenuOffset = 1;
    [SerializeField] private int toErutaraIntroOffset = 9;
    [SerializeField] private int toNukarielIntroOffset = 15;

    private int pHour;
    private int pMinute;
    private int playerID;
    private string characterName;
    private string characterGender;
    private int worldID;
    private int difficultyID;
    private int sendTo;


    public TMP_InputField hourField;
    public TMP_InputField minuteField;
    public TMP_InputField nameField;
    public TMP_Dropdown genderField;
    public GameObject popupNotif;
    public TMP_Text popupText;
    public GameObject durationObject;
    public GameObject storyObject;
    public GameObject characterObject;
    public GameObject difficultyObject;


    public void BackToMenu()
    {
        DurationData.durationInstance._hour = 0;
        DurationData.durationInstance._minute = 0;
        DurationData.durationInstance._second = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }

    public void PushDuration()
    {
        
        string iHour = hourField.text.ToString();
        string iMinute = minuteField.text.ToString();
        int.TryParse(iHour, out int x);
        int.TryParse(iMinute, out int y);
        pHour = x;
        pMinute = y;
        if (iHour.Equals("") && iMinute.Equals(""))
        {
            popupNotif.SetActive(true);
            popupText.text = "Mohon mengisi jam atau menit untuk durasi bermain";
            hourField.text = "";
            minuteField.text = "";
        }
        else if (pMinute < 15 && pHour < 1)
        {
            popupNotif.SetActive(true);
            popupText.text = "Durasi bermain minimal 15 menit";
            minuteField.text = "";
        }
        else if (pHour >= 1 || pMinute >= 15)
        {
            hourField.text = "";
            minuteField.text = "";
            DurationData.durationInstance._hour = pHour;
            DurationData.durationInstance._minute = pMinute;
            DurationData.durationInstance._second = 0;
            storyObject.SetActive(true);
        }
    }

    public void ReturnDuration()
    {
        DurationData.durationInstance._hour = 0;
        DurationData.durationInstance._minute = 0;
        DurationData.durationInstance._second = 0;
        storyObject.SetActive(false);
    }

    public void SelectStoryErutara()
    {
        worldID = 1;
        PlayerTrack.playerInstance._worldID = worldID;
        characterObject.SetActive(true);
    }

    public void SelectStoryNukariel()
    {
        worldID = 2;
        PlayerTrack.playerInstance._worldID = worldID;
        characterObject.SetActive(true);
    }

    public void ReturnStory()
    {
        PlayerTrack.playerInstance._playerID = 0;
        PlayerTrack.playerInstance._characterName = "";
        PlayerTrack.playerInstance._characterGender = "";
        PlayerTrack.playerInstance._worldID = 0;
        PlayerTrack.playerInstance._profileID = 0;
        nameField.text = "";
        characterObject.SetActive(false);
    }

    public void CreateCharacter()
    {
        // Get the transform component from the dropdown
        var dropdown = genderField.transform.GetComponent<TMP_Dropdown>();
        // Get the index of selected option
        int index = dropdown.value;
        // List all the options from the dropdown
        List<TMP_Dropdown.OptionData> menuOptions = dropdown.options;
        string pName = nameField.text.ToString();
        string pGender = menuOptions[index].text.ToString();

        if (pName.Equals("") || pName.Length < 3)
        {
            popupNotif.SetActive(true);
            popupText.text = "Nama tidak boleh kosong atau kurang dari 3 huruf";
            nameField.text = "";
        }
        else if (pName.Length >= 3)
        {
            int saveNum = SaveSystemPlayer.CountSaveFiles();
            saveNum += 1;
            if(saveNum <= 5)
            {
                PlayerTrack.playerInstance._playerID = saveNum;
            }
            else
            {
                saveNum -= 1;
                PlayerTrack.playerInstance._playerID = saveNum;
            }

            PlayerTrack.playerInstance._characterName = pName;
            PlayerTrack.playerInstance._characterGender = pGender;
            PlayerTrack.playerInstance._profileID = PlayerProfile.profileInstance._profileID;
            difficultyObject.SetActive(true);
        }
    }

    public void ReturnCharacter()
    {
        DifficultyData.difficultyInstance._questID = 0;
        DifficultyData.difficultyInstance._energyLimit = 0;
        DifficultyData.difficultyInstance._missionID = 0;
        PlayerTrack.playerInstance._questID = 0;
        PlayerTrack.playerInstance._missionID = 0;
        PlayerTrack.playerInstance._energy = 0;
        difficultyObject.SetActive(false);
    }

    public void SelectEasy()
    {
        DifficultyData.difficultyInstance._questID = 1;
        DifficultyData.difficultyInstance._energyLimit = 200;
        DifficultyData.difficultyInstance._missionID = 1;
        PlayerTrack.playerInstance._questID = 1;
        PlayerTrack.playerInstance._missionID = 1;
        PlayerTrack.playerInstance._energy = 200;
        sendTo = SelectWorld(PlayerTrack.playerInstance._worldID);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sendTo);
    }

    public void SelectNormal()
    {
        DifficultyData.difficultyInstance._questID = 1;
        DifficultyData.difficultyInstance._energyLimit = 180;
        DifficultyData.difficultyInstance._missionID = 1;
        PlayerTrack.playerInstance._questID = 1;
        PlayerTrack.playerInstance._missionID = 1;
        PlayerTrack.playerInstance._energy = 180;
        sendTo = SelectWorld(PlayerTrack.playerInstance._worldID);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sendTo);
    }

    public void SelectHard()
    {
        DifficultyData.difficultyInstance._questID = 1;
        DifficultyData.difficultyInstance._energyLimit = 150;
        DifficultyData.difficultyInstance._missionID = 1;
        PlayerTrack.playerInstance._questID = 1;
        PlayerTrack.playerInstance._missionID = 1;
        PlayerTrack.playerInstance._energy = 150;
        sendTo = SelectWorld(PlayerTrack.playerInstance._worldID);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sendTo);
    }

    public int SelectWorld(int worldID)
    {
        int sendID;
        if (worldID == 1)
        {
            sendID = toErutaraIntroOffset;
        }
        else if (worldID == 2)
        {
            sendID = toNukarielIntroOffset;
        }
        else
        {
            return 0;
        }

        return sendID;
    }

}
