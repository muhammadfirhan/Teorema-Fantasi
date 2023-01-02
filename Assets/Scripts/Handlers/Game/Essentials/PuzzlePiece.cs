using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    readonly float[] rotations = { 0, 90, 180, 270 };
    private CorrectPiece puzzleCorrect;

    private void Start()
    {
        puzzleCorrect = gameObject.GetComponent<CorrectPiece>();
        int randomRotate = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[randomRotate]);
    }

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
}
