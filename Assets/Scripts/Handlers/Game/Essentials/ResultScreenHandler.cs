using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultScreenHandler : MonoBehaviour
{
    public void ToMainMenu()
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
        SceneManager.LoadScene("Main_Menu");
    }
}
