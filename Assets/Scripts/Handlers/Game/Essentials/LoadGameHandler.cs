using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameHandler : MonoBehaviour
{
    private GameObject playerObject;

    private void Awake()
    {
        if (SceneStateData._previousScene.Equals("Menu_SelectSave"))
        {
            Debug.Log("Save loaded");
            SetPlayerPos();
        }
    }
    private void SetPlayerPos()
    {
        playerObject = GameObject.FindWithTag("Player");
        PlayerData data = SaveSystemPlayer.LoadPlayer(PlayerTrack.playerInstance._playerID);
        if (data != null)
        {
            float posX = data._position[0];
            float posY = data._position[1];
            float posZ = data._position[2];

            playerObject.transform.position = new Vector3(posX, posY, posZ);
        }
        else
        {
            playerObject.transform.position = new Vector3(0, 0, 0);
        }
        //Vector3 savePos = PlayerTrack.playerInstance.LoadSavePos(PlayerTrack.playerInstance._playerID);
        //playerObject.transform.position = savePos;
        //playerObject = null;
    }
}
