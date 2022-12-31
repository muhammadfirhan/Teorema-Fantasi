using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalHandler : MonoBehaviour
{
    public TMP_Text worldInfoText;
    public TMP_Text timerText;
    public TMP_Text difficultyText;
    public TMP_Text totalMissionText;

    private float TimeLeft;
    public bool TimerOn = false;

    private void OnEnable()
    {
        TimeLeft = DurationData.durationInstance._second;
        TimerOn = true;
        if (PlayerTrack.playerInstance._worldID == 1)
        {
            worldInfoText.text = "Dunia: Erutara";
            if( PlayerTrack.playerInstance._diffID == 1)
            {
                difficultyText.text = "Kesulitan: Mudah";
            }
            else if (PlayerTrack.playerInstance._diffID == 2)
            {
                difficultyText.text = "Kesulitan: Sedang";
            }
            else if (PlayerTrack.playerInstance._diffID == 3)
            {
                difficultyText.text = "Kesulitan: Sulit";
            }
            totalMissionText.text = "Jumlah Misi: 6";
        }
        else if (PlayerTrack.playerInstance._worldID == 2)
        {
            worldInfoText.text = "Dunia: Nukariel";
            if (PlayerTrack.playerInstance._diffID == 1)
            {
                difficultyText.text = "Kesulitan: Mudah";
            }
            else if (PlayerTrack.playerInstance._diffID == 2)
            {
                difficultyText.text = "Kesulitan: Sedang";
            }
            else if (PlayerTrack.playerInstance._diffID == 3)
            {
                difficultyText.text = "Kesulitan: Sulit";
            }
            totalMissionText.text = "Jumlah Misi: 10";
        }
    }

    private void OnDisable()
    {
        TimerOn = false;
        TimeLeft = 0;
    }

    private void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                //DurationData.durationInstance._second -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            } 
            else if (TimeLeft == 180)
            {
                Debug.Log("Waktu tersisa 3 menit lagi");
                Debug.Log("Mohon menyimpan");
            }
            else
            {
                Debug.Log("Waktu habis");
                TimeLeft = 0;
                //DurationData.durationInstance._second = 0;
                TimerOn = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("Waktu tersisa: {0:00} : {1:00}", minutes, seconds);
    }
}
