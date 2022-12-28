using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPlayerRankingHandler : MonoBehaviour
{
    [SerializeField] private int toProfileOffset = 3;

    private void Start()
    {
        SceneStateData.sceneInstance.SetCurrent();
    }

    public void ToProfile()
    {
        SceneStateData.sceneInstance.SetPrevious();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toProfileOffset);
    }
}
