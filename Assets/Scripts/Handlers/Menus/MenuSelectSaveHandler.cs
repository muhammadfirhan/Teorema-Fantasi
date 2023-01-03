using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSelectSaveHandler : MonoBehaviour
{
    public GameObject durationObject;
    public GameObject popupNotif;

    public TMP_InputField hourField;
    public TMP_InputField minuteField;
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
    public TMP_Text popupText;

    public string sceneName;
    private int pHour;
    private int pMinute;

    [SerializeField] private int toMainMenuOffset = 2;

    private void Start()
    {
        GetSaves();
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
        else if (pMinute >= 15 || pHour >= 1)
        {
            hourField.text = "";
            minuteField.text = "";
            DurationData.durationInstance._hour = pHour;
            DurationData.durationInstance._minute = pMinute;
            DurationData.durationInstance._second = (pHour * 3600) + (pMinute * 60);
            if(PlayerTrack.playerInstance._diffID == 1)
            {
                DifficultyData.difficultyInstance._diffID = 1;
                DifficultyData.difficultyInstance._questID = PlayerTrack.playerInstance._questID;
                DifficultyData.difficultyInstance._energyLimit = 200;
                DifficultyData.difficultyInstance._missionID = PlayerTrack.playerInstance._missionID;
            }
            else if(PlayerTrack.playerInstance._diffID == 2)
            {
                DifficultyData.difficultyInstance._diffID = 2;
                DifficultyData.difficultyInstance._questID = PlayerTrack.playerInstance._questID;
                DifficultyData.difficultyInstance._energyLimit = 180;
                DifficultyData.difficultyInstance._missionID = PlayerTrack.playerInstance._missionID;
            }
            else if (PlayerTrack.playerInstance._diffID == 3)
            {
                DifficultyData.difficultyInstance._diffID = 3;
                DifficultyData.difficultyInstance._questID = PlayerTrack.playerInstance._questID;
                DifficultyData.difficultyInstance._energyLimit = 150;
                DifficultyData.difficultyInstance._missionID = PlayerTrack.playerInstance._missionID;
            }
            PositionTracking.positionInstance.SetPosition(PlayerTrack.playerInstance._worldID);
            SceneManager.LoadScene(sceneName);
        }
    }

    public void BackToMenu()
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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }

    public void ReturnSaves()
    {
        DurationData.durationInstance._hour = 0;
        DurationData.durationInstance._minute = 0;
        DurationData.durationInstance._second = 0;
        PlayerTrack.playerInstance._playerID = 0 ;
        PlayerTrack.playerInstance._characterName = null;
        PlayerTrack.playerInstance._characterGender = null;
        PlayerTrack.playerInstance._questID = 0;
        PlayerTrack.playerInstance._missionID = 0;
        PlayerTrack.playerInstance._worldID = 0;
        PlayerTrack.playerInstance._energy = 0;
        PlayerTrack.playerInstance._sceneID = 0;
        PlayerTrack.playerInstance._diffID = 0;
        PlayerTrack.playerInstance._profileID = 0;
        sceneName = "";

        durationObject.SetActive(false);
    }

    public void SelectSave1()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(1);

        if (data != null)
        {
            PlayerTrack.playerInstance._playerID = data._id;
            PlayerTrack.playerInstance._characterName= data._characterName;
            PlayerTrack.playerInstance._characterGender = data._characterGender;
            PlayerTrack.playerInstance._questID= data._questID;
            PlayerTrack.playerInstance._missionID = data._missionID;
            PlayerTrack.playerInstance._worldID = data._worldID;
            PlayerTrack.playerInstance._energy = data._energy;
            PlayerTrack.playerInstance._sceneID = data._sceneID;
            PlayerTrack.playerInstance._diffID = data._diffID;
            PlayerTrack.playerInstance._profileID = data._profileID;

            sceneName = GetScene(data._worldID, data._sceneID);
            durationObject.SetActive(true);
        }
        else
        {
            Debug.Log("No save file detected");
        }
    }

    public void SelectSave2()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(2);

        if (data != null)
        {
            PlayerTrack.playerInstance._playerID = data._id;
            PlayerTrack.playerInstance._characterName = data._characterName;
            PlayerTrack.playerInstance._characterGender = data._characterGender;
            PlayerTrack.playerInstance._questID = data._questID;
            PlayerTrack.playerInstance._missionID = data._missionID;
            PlayerTrack.playerInstance._worldID = data._worldID;
            PlayerTrack.playerInstance._energy = data._energy;
            PlayerTrack.playerInstance._sceneID = data._sceneID;
            PlayerTrack.playerInstance._diffID = data._diffID;
            PlayerTrack.playerInstance._profileID = data._profileID;

            sceneName = GetScene(data._worldID, data._sceneID);
            durationObject.SetActive(true);
        }
        else
        {
            Debug.Log("No save file detected");
        }
    }

    public void SelectSave3()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(3);

        if (data != null)
        {
            PlayerTrack.playerInstance._playerID = data._id;
            PlayerTrack.playerInstance._characterName = data._characterName;
            PlayerTrack.playerInstance._characterGender = data._characterGender;
            PlayerTrack.playerInstance._questID = data._questID;
            PlayerTrack.playerInstance._missionID = data._missionID;
            PlayerTrack.playerInstance._worldID = data._worldID;
            PlayerTrack.playerInstance._energy = data._energy;
            PlayerTrack.playerInstance._sceneID = data._sceneID;
            PlayerTrack.playerInstance._diffID = data._diffID;
            PlayerTrack.playerInstance._profileID = data._profileID;

            sceneName = GetScene(data._worldID, data._sceneID);
            durationObject.SetActive(true);
        }
        else
        {
            Debug.Log("No save file detected");
        }
    }

    public void SelectSave4()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(1);

        if (data != null)
        {
            PlayerTrack.playerInstance._playerID = data._id;
            PlayerTrack.playerInstance._characterName = data._characterName;
            PlayerTrack.playerInstance._characterGender = data._characterGender;
            PlayerTrack.playerInstance._questID = data._questID;
            PlayerTrack.playerInstance._missionID = data._missionID;
            PlayerTrack.playerInstance._worldID = data._worldID;
            PlayerTrack.playerInstance._energy = data._energy;
            PlayerTrack.playerInstance._sceneID = data._sceneID;
            PlayerTrack.playerInstance._diffID = data._diffID;
            PlayerTrack.playerInstance._profileID = data._profileID;

            sceneName = GetScene(data._worldID, data._sceneID);
            durationObject.SetActive(true);
        }
        else
        {
            Debug.Log("No save file detected");
        }
    }

    public void SelectSave5()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(1);

        if (data != null)
        {
            PlayerTrack.playerInstance._playerID = data._id;
            PlayerTrack.playerInstance._characterName = data._characterName;
            PlayerTrack.playerInstance._characterGender = data._characterGender;
            PlayerTrack.playerInstance._questID = data._questID;
            PlayerTrack.playerInstance._missionID = data._missionID;
            PlayerTrack.playerInstance._worldID = data._worldID;
            PlayerTrack.playerInstance._energy = data._energy;
            PlayerTrack.playerInstance._sceneID = data._sceneID;
            PlayerTrack.playerInstance._diffID = data._diffID;
            PlayerTrack.playerInstance._profileID = data._profileID;

            sceneName = GetScene(data._worldID, data._sceneID);
            durationObject.SetActive(true);
        }
        else
        {
            Debug.Log("No save file detected");
        }
    }

    public string GetScene(int worldID, int sceneID)
    {
        string result;

        if (worldID == 1)
        {
            if (sceneID == 1)
            {
                result = "Erutara_Intro";
            }
            else if (sceneID == 2)
            {
                result = "Erutara_Dungeon";
            }
            else if (sceneID == 3)
            {
                result = "Erutara_Open";
            }
            else if (sceneID == 4)
            {
                result = "Erutara_Hall";
            }
            else if (sceneID == 5)
            {
                result = "Erutara_Library";
            }
            else if (sceneID == 6)
            {
                result = "Erutara_Outro";
            }
            else
            {
                result = null;
            }
        }
        else if (worldID == 2)
        {
            if (sceneID == 1)
            {
                result = "Nukariel_Intro";
            }
            else if (sceneID == 2)
            {
                result = "Nukariel_Castle";
            }
            else if (sceneID == 3)
            {
                result = "Nukariel_Forest";
            }
            else if (sceneID == 4)
            {
                result = "Nukariel_Hut";
            }
            else if (sceneID == 5)
            {
                result = "Nukariel_Cave";
            }
            else if (sceneID == 6)
            {
                result = "Nukariel_Outro";
            }
            else
            {
                result = null;
            }
        }
        else
        {
            result = null;
        }

        return result;
    }
}
