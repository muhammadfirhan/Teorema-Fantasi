using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ErutaraDungeonUIHandler : MonoBehaviour
{
    public GameObject controllerObject;
    public GameObject pauseObject;
    public GameObject mapUI;
    public GameObject mapObject;
    public GameObject journalUI;
    public GameObject journalObject;
    public GameObject energyUI;
    [SerializeField] private GameObject playerObject;

    private int energyLimit;
    private float waitAddEnergy = 60f;

    private void Awake()
    {
        if (SceneStateData._previousScene.Equals("Erutara_Open"))
        {
            float posX = PositionTracking.positionInstance._position1[0];
            float posY = PositionTracking.positionInstance._position1[1];
            float posZ = PositionTracking.positionInstance._position1[2];
            playerObject = GameObject.FindWithTag("Player");
            Debug.Log("About to move player (currently located at " + playerObject.transform.position +
                ") at the position " + new Vector3(posX, posY, posZ));
            SetPlayerPos(posX, posY, posZ);
            Debug.Log("Player has been moved at " + playerObject.transform.position);
        }
        else if (SceneStateData._previousScene.Equals("Puzzle_Type1"))
        {

            float posX = PositionTracking.positionInstance._tempPos[0];
            float posY = PositionTracking.positionInstance._tempPos[1];
            float posZ = PositionTracking.positionInstance._tempPos[2];
            playerObject = GameObject.FindWithTag("Player");
            Debug.Log("About to move player (currently located at " + playerObject.transform.position +
                ") at the position " + new Vector3(posX, posY, posZ));
            SetPlayerPos(posX, posY, posZ);
            Debug.Log("Player has been moved at " + playerObject.transform.position);
        }
        StartCoroutine(SetTimer());
        energyLimit = DifficultyData.difficultyInstance._energyLimit;
        if (PlayerTrack.playerInstance._missionID >= 2)
        {
            mapUI.SetActive(true);
            journalUI.SetActive(true);
            energyUI.SetActive(true);
            UpdateEnergy();
        }
    }

    private void Update()
    {
        if (DurationData.durationInstance._second == 180)
        {
            Debug.Log("Waktu tersisa 3 menit lagi");
            Debug.Log("Mohon menyimpan");
        }
        else if (DurationData.durationInstance._second <= 0) 
        {
            Debug.Log("Waktu habis");
            DurationData.durationInstance._second = 0;
            StopCoroutine(SetTimer());
            SaveSystemPlayer.SavePlayer();
            StartCoroutine(SaveTime());
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

    public void TriggerEnergy()
    {
        if (PlayerTrack.playerInstance._missionID >= 2)
        {
            UpdateEnergy();
        }
    }

    public void ShowPause()
    {
        pauseObject.SetActive(true);
    }

    public void ShowMap()
    {
        mapObject.SetActive(true);
    }

    public void ShowJournal()
    {
        journalObject.SetActive(true);
    }

    void UpdateEnergy()
    {
        TMP_Text energyText = energyUI.GetComponentInChildren<TMP_Text>();
        energyText.text = PlayerTrack.playerInstance._energy + "/" + energyLimit;
        StartCoroutine(AddEnergy(energyText));
    }

    private void SetPlayerPos(float posX, float posY, float posZ)
    {
        playerObject = GameObject.FindWithTag("Player");
        playerObject.transform.position = new Vector3(posX, posY, posZ);
    }

    IEnumerator AddEnergy(TMP_Text theText)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitAddEnergy);
            if (PlayerTrack.playerInstance._energy < energyLimit)
            {
                PlayerTrack.playerInstance._energy += 1;
                theText.text = PlayerTrack.playerInstance._energy + "/" + energyLimit;
            }
            else
            {
                theText.text = PlayerTrack.playerInstance._energy + "/" + energyLimit;
            }
        }
    }
    
    IEnumerator SaveTime()
    {
        yield return new WaitForSeconds(2);
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
