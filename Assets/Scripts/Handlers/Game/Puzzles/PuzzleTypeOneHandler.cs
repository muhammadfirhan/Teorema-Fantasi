using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PuzzleTypeOneHandler : MonoBehaviour
{
    public GameObject pauseObject;
    public GameObject resultObject;
    public TMP_Text timerText;
    public TMP_Text resultText;
    public TMP_Text pointText;
    public TMP_Text coinText;
    public TMP_Text energyText;

    private float TimeLeft;
    public bool TimerOn = false;
    public bool GameEnded = false;

    private void Awake()
    {
        StartCoroutine(SetTimer());
        if (PlayerTrack.playerInstance._diffID == 1)
        {
            TimeLeft = 300f;
        }
        else if (PlayerTrack.playerInstance._diffID == 2)
        {
            TimeLeft = 240f;
        }
        else if (PlayerTrack.playerInstance._diffID == 3)
        {
            TimeLeft = 180;
        }
        TimerOn = true;
    }

    public void ShowPause()
    {
        pauseObject.SetActive(true);
    }

    public void SetCondition()
    {
        TimerOn = false;
        TimeLeft = 0;
    }

    private void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0 && GameEnded == false)
            {
                TimeLeft -= Time.deltaTime;
                //DurationData.durationInstance._second -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else if (TimeLeft <= 0)
            {
                ResultScreen(2);
            }
        }
    }

    IEnumerator SetTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            DurationData.durationInstance._second -= 1;
        }
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("Waktu tersisa: {0:00} : {1:00}", minutes, seconds);
    }

    public void ResultScreen(int eventID)
    {
        SetCondition();
        SetResultText(eventID);
        resultObject.SetActive(true);
    }

    public void SetResultText(int eventID)
    {
        int energyVal = 0;
        if (eventID == 1)
        {
            if (PlayerTrack.playerInstance._worldID == 1 && PlayerTrack.playerInstance._missionID < 5
                || PlayerTrack.playerInstance._worldID == 2 && PlayerTrack.playerInstance._missionID < 7)
            {
                resultText.text = "Anda berhasil";
                if (PlayerTrack.playerInstance._diffID == 1)
                {
                    energyVal = 2;
                    PlayerTrack.playerInstance._energy -= 2;
                    PlayerProfile.profileInstance._profileCoin += 5;
                    PlayerProfile.profileInstance._profilePoint += 50;
                }
                else if (PlayerTrack.playerInstance._diffID == 2)
                {
                    energyVal = 4;
                    PlayerTrack.playerInstance._energy -= 4;
                    PlayerProfile.profileInstance._profileCoin += 10;
                    PlayerProfile.profileInstance._profilePoint += 125;
                }
                else if (PlayerTrack.playerInstance._diffID == 3)
                {
                    energyVal = 8;
                    PlayerTrack.playerInstance._energy -= 8;
                    PlayerProfile.profileInstance._profileCoin += 20;
                    PlayerProfile.profileInstance._profilePoint += 250;
                }
                PlayerTrack.playerInstance._questID += 1;
                pointText.text = "Poin yang didapat: " + PlayerProfile.profileInstance._profilePoint;
                coinText.text = "Koin yang didapat: " + PlayerProfile.profileInstance._profileCoin;
                energyText.text = "Energi yang digunakan: " + energyVal;
            } 
            else if (PlayerTrack.playerInstance._worldID == 1 && PlayerTrack.playerInstance._missionID == 5
                || PlayerTrack.playerInstance._worldID == 2 && PlayerTrack.playerInstance._missionID == 7)
            {
                resultText.text = "Anda berhasil menyelesaikan cerita!";
                if (PlayerTrack.playerInstance._diffID == 1)
                {
                    PlayerProfile.profileInstance._profileCoin += 25;
                    PlayerProfile.profileInstance._profilePoint += 250;
                }
                else if (PlayerTrack.playerInstance._diffID == 2)
                {
                    PlayerProfile.profileInstance._profileCoin += 50;
                    PlayerProfile.profileInstance._profilePoint += 625;
                }
                else if (PlayerTrack.playerInstance._diffID == 3)
                {
                    PlayerProfile.profileInstance._profileCoin += 100;
                    PlayerProfile.profileInstance._profilePoint += 1250;
                }
                energyText.gameObject.SetActive(false);
                pointText.text = "Poin yang didapat: " + PlayerProfile.profileInstance._profilePoint;
                coinText.text = "Koin yang didapat: " + PlayerProfile.profileInstance._profileCoin;
            }
            else if (PlayerTrack.playerInstance._worldID == 1 && PlayerTrack.playerInstance._missionID == 6
                || PlayerTrack.playerInstance._worldID == 2 && PlayerTrack.playerInstance._missionID == 10)
            {
                resultText.text = "Anda berhasil menyelesaikan \nCerita tersembunyi!";
                if (PlayerTrack.playerInstance._diffID == 1)
                {
                    PlayerProfile.profileInstance._profileCoin += 50;
                    PlayerProfile.profileInstance._profilePoint += 500;
                }
                else if (PlayerTrack.playerInstance._diffID == 2)
                {
                    PlayerProfile.profileInstance._profileCoin += 100;
                    PlayerProfile.profileInstance._profilePoint += 1000;
                }
                else if (PlayerTrack.playerInstance._diffID == 3)
                {
                    PlayerProfile.profileInstance._profileCoin += 200;
                    PlayerProfile.profileInstance._profilePoint += 2500;
                }
                energyText.gameObject.SetActive(false);
                pointText.text = "Poin yang didapat: " + PlayerProfile.profileInstance._profilePoint;
                coinText.text = "Koin yang didapat: " + PlayerProfile.profileInstance._profileCoin;
            }
        }
        else if (eventID == 2)
        {
            resultText.text = "Anda gagal";
            if (PlayerTrack.playerInstance._diffID == 1)
            {
                energyVal = 5;
                PlayerTrack.playerInstance._energy -= 5;
            }
            else if (PlayerTrack.playerInstance._diffID == 2)
            {
                energyVal = 10;
                PlayerTrack.playerInstance._energy -= 10;
            }
            else if (PlayerTrack.playerInstance._diffID == 3)
            {
                energyVal = 20;
                PlayerTrack.playerInstance._energy -= 20;
            }
            pointText.gameObject.SetActive(false);
            coinText.gameObject.SetActive(false);
            energyText.rectTransform.position = new Vector3(0, 0, 0);
            energyText.text = "Energi yang digunakan: " + energyVal;
        }
    }

    public void ContinueGame()
    {
        string sceneName = GetScene(PlayerTrack.playerInstance._worldID, PlayerTrack.playerInstance._sceneID);
        SceneManager.LoadScene(sceneName);
    }

    public string GetScene(int worldID, int sceneID)
    {
        string result;

        if (worldID == 1)
        {
            if (sceneID == 2)
            {
                result = "Erutara_Dungeon";
            }
            else if (sceneID == 5)
            {
                result = "Erutara_Library";
            }
            else
            {
                result = null;
            }
        }
        else if (worldID == 2)
        {
            if (sceneID == 2)
            {
                result = "Nukariel_Castle";
            }
            else if (sceneID == 4)
            {
                result = "Nukariel_Hut";
            }
            else if (sceneID == 5)
            {
                result = "Nukariel_Cave";
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
