using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoosePuzzleTwo : MonoBehaviour
{
    public GameObject puzzleHolder;
    public GameObject[] puzzleObject;
    public GameObject[] patternObject;

    [SerializeField] int totalPuzzle = 0;
    [SerializeField] int totalPattern = 0;

    private void Start()
    {
        totalPuzzle = puzzleHolder.transform.childCount;
        puzzleObject = new GameObject[totalPuzzle];
        for (int i = 0; i < puzzleObject.Length; i++)
        {
            puzzleObject[i] = puzzleHolder.transform.GetChild(i).gameObject;
        }
        int randomNum = Random.Range(0, puzzleObject.Length);
        totalPattern = puzzleObject[randomNum].transform.childCount;
        patternObject = new GameObject[totalPattern];
        for (int i = 0; i < patternObject.Length; i++)
        {
            patternObject[i] = puzzleObject[randomNum].transform.GetChild(i).gameObject;
        }
        int randomPuzzle = Random.Range(0, patternObject.Length);
        patternObject[randomPuzzle].SetActive(true);
    }
}
