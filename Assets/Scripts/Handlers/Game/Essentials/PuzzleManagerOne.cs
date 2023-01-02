using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerOne : MonoBehaviour
{
    public GameObject piecesHolder1;
    public GameObject[] pieces1;

    [SerializeField] int totalpieces1 = 0;

    private void Start()
    {
        totalpieces1 = piecesHolder1.transform.childCount;
        pieces1 = new GameObject[totalpieces1];
        
        for (int i = 0; i < pieces1.Length; i++)
        {
            pieces1[i] = piecesHolder1.transform.GetChild(i).gameObject;
        }
    }
}
