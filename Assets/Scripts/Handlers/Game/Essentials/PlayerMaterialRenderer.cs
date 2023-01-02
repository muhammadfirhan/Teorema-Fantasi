using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterialRenderer : MonoBehaviour
{
    private void Awake()
    {
        Renderer playerRenderer = GetComponent<Renderer>();
        Material playerMat = playerRenderer.material;
        if (PlayerTrack.playerInstance._characterGender.Equals("Laki-Laki"))
        {
            playerMat.color = new Color(0, 0, 255);
        }else if (PlayerTrack.playerInstance._characterGender.Equals("Perempuan"))
        {
            playerMat.color = new Color(255, 0, 255);
        }
    }
}
