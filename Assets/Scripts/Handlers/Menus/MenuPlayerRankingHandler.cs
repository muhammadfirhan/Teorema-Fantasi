using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPlayerRankingHandler : MonoBehaviour
{
    [SerializeField] private int toProfileOffset = 3;

    public void toProfile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toProfileOffset);
    }
}
