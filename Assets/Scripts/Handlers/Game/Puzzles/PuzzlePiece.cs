using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    readonly float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField] bool isPlaced = false;

    int possibleRotations = 1;

    PuzzleManagerOne puzzleManager1;

    private void Awake()
    {
        puzzleManager1 = GameObject.Find("PuzzleManager1").GetComponent<PuzzleManagerOne>();
    }

    private void Start()
    {
        possibleRotations = correctRotation.Length;
        int randomRotate = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[randomRotate]);


        if (possibleRotations > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                puzzleManager1.CorrectMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                puzzleManager1.CorrectMove();
            }
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (possibleRotations > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1]
                && isPlaced == false)
            {
                isPlaced = true;
                puzzleManager1.CorrectMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                puzzleManager1.WrongMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0] && isPlaced == false)
            {
                isPlaced = true;
                puzzleManager1.CorrectMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                puzzleManager1.WrongMove();
            }
        }
    }

    /*
    public void RotateRight()
    {
        if (transform.eulerAngles.z >= 90)
        {
            transform.Rotate(new Vector3(0, 0, -90));
            puzzleCorrect.GetRotation();
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 270));
            puzzleCorrect.GetRotation();
        }
    }
    */
    /*
    public void RotateLeft()
    {
        if (transform.eulerAngles.z <= 270)
        {
            transform.Rotate(new Vector3(0, 0, 90));
            puzzleCorrect.GetRotation();
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -270));
            puzzleCorrect.GetRotation();
        }
    }
    */
}
