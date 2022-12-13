using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateProfileDropDownHandler : MonoBehaviour
{
    public GameObject maleLogo;
    public GameObject femaleLogo;

    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<TMP_Dropdown>();

        dropdown.onValueChanged.AddListener(delegate { DropDownItemSelected(dropdown); });
    }

    void DropDownItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        if(index == 0)
        {
            maleLogo.SetActive(true);
            femaleLogo.SetActive(false);
        }else if(index == 1)
        {
            maleLogo.SetActive(false);
            femaleLogo.SetActive(true);
        }
    }
}
