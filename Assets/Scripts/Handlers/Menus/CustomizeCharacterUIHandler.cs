using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CustomizeCharacterUIHandler : MonoBehaviour
{
    [SerializeField] private int toProfileOffset = 24;

    public void ToProfile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toProfileOffset);
    }
}
