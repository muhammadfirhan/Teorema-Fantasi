using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuShopHandler : MonoBehaviour
{
    [SerializeField] private int toProfileOffset = 2;

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
