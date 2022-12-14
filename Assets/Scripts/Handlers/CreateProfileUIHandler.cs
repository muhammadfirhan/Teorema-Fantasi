using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreateProfileUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField ageField;
    public TMP_Dropdown genderField;

    public void Create_Profile()
    {
        int y;
        var dropdown = genderField.transform.GetComponent<TMP_Dropdown>();
        int index = dropdown.value;
        List<TMP_Dropdown.OptionData> menuOptions = dropdown.options;
        string pName = nameField.text.ToString();
        int.TryParse(ageField.text.ToString(), out y);
        int pAge = y;
        string pGender = menuOptions[index].text.ToString();
        Debug.Log(pName);
        Debug.Log(pAge);
        Debug.Log(pGender);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
