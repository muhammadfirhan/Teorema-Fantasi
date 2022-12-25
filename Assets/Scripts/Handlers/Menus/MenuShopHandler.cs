using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuShopHandler : MonoBehaviour
{
    [SerializeField] private int toProfileOffset = 2;

    public void ToProfile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toProfileOffset);
    }
}
