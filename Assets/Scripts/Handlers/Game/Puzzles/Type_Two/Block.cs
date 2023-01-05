using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float posX;
    public float posY;
    public bool isPlaced = false;

    private void Start()
    {
        SetDefPos();
    }

    public void SetDefPos()
    {
        posX = gameObject.transform.position.x;
        posY = gameObject.transform.position.y;
    }
}
