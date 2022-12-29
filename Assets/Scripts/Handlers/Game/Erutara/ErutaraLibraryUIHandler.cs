using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErutaraLibraryUIHandler : MonoBehaviour
{
    public GameObject controllerObject;
    public GameObject pauseObject;

    public void showPause()
    {
        pauseObject.SetActive(true);
    }
}
