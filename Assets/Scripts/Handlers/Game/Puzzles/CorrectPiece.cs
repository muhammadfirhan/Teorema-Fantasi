using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPiece : MonoBehaviour
{
    public float correctRotation1;
    public float correctRotation2;
    public float correctRotation3;
    public float correctRotation4;
    [SerializeField] private bool isPlaced = false;

    private void Start()
    {
        if (transform.eulerAngles.z == correctRotation1 || transform.eulerAngles.z == correctRotation2
            || transform.eulerAngles.z == correctRotation3 || transform.eulerAngles.z == correctRotation4)
        {
            isPlaced = true;
        }
    }

    public void GetRotation()
    {
        if ((transform.eulerAngles.z == correctRotation1 || transform.eulerAngles.z == correctRotation2
            || transform.eulerAngles.z == correctRotation3 || transform.eulerAngles.z == correctRotation4)
            && isPlaced == false)
        {
            isPlaced = true;
        }
        else if (isPlaced == true)
        {
            isPlaced = false;
        }
    }
}
