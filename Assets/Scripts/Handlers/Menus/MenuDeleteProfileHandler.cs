using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuDeleteProfileHandler : MonoBehaviour
{
    public GameObject profile1;
    public GameObject profile2;
    public GameObject profile3;
    public GameObject profile4;
    public GameObject profile5;
    public GameObject profile6;
    public GameObject profile7;
    public GameObject profile8;
    public GameObject profile9;
    public GameObject profile10;

    [SerializeField] private int toProfileOffset = 6;
    [SerializeField] private int toSelectProfileOffset = 1;

    TMP_Text profText1;
    TMP_Text profText2;
    TMP_Text profText3;
    TMP_Text profText4;
    TMP_Text profText5;
    TMP_Text profText6;
    TMP_Text profText7;
    TMP_Text profText8;
    TMP_Text profText9;
    TMP_Text profText10;

    public void ToProfile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toProfileOffset);
    }

    private void Start()
    {
        GetProfile();
    }

    public void GetProfile()
    {
        profText1 = profile1.GetComponentInChildren<TMP_Text>();
        profText2 = profile2.GetComponentInChildren<TMP_Text>();
        profText3 = profile3.GetComponentInChildren<TMP_Text>();
        profText4 = profile4.GetComponentInChildren<TMP_Text>();
        profText5 = profile5.GetComponentInChildren<TMP_Text>();
        profText6 = profile6.GetComponentInChildren<TMP_Text>();
        profText7 = profile7.GetComponentInChildren<TMP_Text>();
        profText8 = profile8.GetComponentInChildren<TMP_Text>();
        profText9 = profile9.GetComponentInChildren<TMP_Text>();
        profText10 = profile10.GetComponentInChildren<TMP_Text>();

        ProfileData data1 = SaveSystemProfile.LoadProfile(1);
        ProfileData data2 = SaveSystemProfile.LoadProfile(2);
        ProfileData data3 = SaveSystemProfile.LoadProfile(3);
        ProfileData data4 = SaveSystemProfile.LoadProfile(4);
        ProfileData data5 = SaveSystemProfile.LoadProfile(5);
        ProfileData data6 = SaveSystemProfile.LoadProfile(6);
        ProfileData data7 = SaveSystemProfile.LoadProfile(7);
        ProfileData data8 = SaveSystemProfile.LoadProfile(8);
        ProfileData data9 = SaveSystemProfile.LoadProfile(9);
        ProfileData data10 = SaveSystemProfile.LoadProfile(10);

        SetText(data1, profText1);
        SetText(data2, profText2);
        SetText(data3, profText3);
        SetText(data4, profText4);
        SetText(data5, profText5);
        SetText(data6, profText6);
        SetText(data7, profText7);
        SetText(data8, profText8);
        SetText(data9, profText9);
        SetText(data10, profText10);
    }

    public void SetText(ProfileData data, TMP_Text profText)
    {
        if (data != null)
        {
            profText.text = data._profileName;
        }
        else
        {
            profText.text = "Buat Profil";
        }
    }

    public void DeleteProfile1()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(1);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }

    public void DeleteProfile2()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(2);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(2);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }
            else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(2);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }

    public void DeleteProfile3()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(3);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(3);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }
            else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(3);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }

    public void DeleteProfile4()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(4);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(4);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }
            else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(4);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }

    public void DeleteProfile5()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(5);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(5);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }
            else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(5);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }

    public void DeleteProfile6()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(6);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(6);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }
            else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(6);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }

    public void DeleteProfile7()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(7);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(7);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }
            else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(7);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }

    public void DeleteProfile8()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(8);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(8);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }
            else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(8);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }

    public void DeleteProfile9()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(9);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(9);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }
            else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(9);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }

    public void DeleteProfile10()
    {
        ProfileData data = SaveSystemProfile.LoadProfile(10);

        if (data != null)
        {
            if (data._id == PlayerProfile.profileInstance._profileID)
            {
                Debug.Log("Active profile deleted");
                SaveSystemProfile.DeleteProfile(10);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - toSelectProfileOffset);
            }
            else
            {
                Debug.Log("Profile deleted");
                SaveSystemProfile.DeleteProfile(10);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            Debug.Log("No profile detected");
        }
    }
}
