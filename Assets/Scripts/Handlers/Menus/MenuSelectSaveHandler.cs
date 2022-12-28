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
        SceneStateData.sceneInstance.SetCurrent();
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
            SceneStateData.sceneInstance.SetPrevious();

            SceneManager.LoadScene(sceneName);
        }
    }

    public void BackToMenu()
    {
        SceneStateData.sceneInstance.SetPrevious();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toMainMenuOffset);
    }

    public void ReturnSaves()
    {
        DurationData.durationInstance._hour = 0;
        DurationData.durationInstance._minute = 0;
        DurationData.durationInstance._second = 0;
        sceneName = "";
        durationObject.SetActive(false);
    }

    public void SelectSave1()
    {
        PlayerData data = SaveSystemPlayer.LoadPlayer(1);

        if (data != null)
        {
            sceneName = GetScene(data._worldID, data._sceneID);
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
            sceneName = GetScene(data._worldID, data._sceneID);
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
            sceneName = GetScene(data._worldID, data._sceneID);
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
            sceneName = GetScene(data._worldID, data._sceneID);
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
            sceneName = GetScene(data._worldID, data._sceneID);
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
                result = "Erutara_Dungeon";
            }
            else if (sceneID == 2)
            {
                result = "Erutara_Open";
            }
            else if (sceneID == 3)
            {
                result = "Erutara_Hall";
            }
            else if (sceneID == 4)
            {
                result = "Erutara_Library";
            }
            else
            {
                result = "Erutara_Intro";
            }
        }
        else if (worldID == 2)
        {
            if (sceneID == 1)
            {
                result = "Nukariel_Castle";
            }
            else if (sceneID == 2)
            {
                result = "Nukariel_Forest";
            }
            else if (sceneID == 3)
            {
                result = "Nukariel_Hut";
            }
            else if (sceneID == 4)
            {
                result = "Nukariel_Cave";
            }
            else
            {
                result = "Nukariel_Intro";
            }
        }
        else
        {
            result = "null";
        }

        return result;
    }
}
