using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProfileData
{
    public int _id;
    public string _profileName;
    public int _profileAge;
    public string _profileGender;
    public int _profileCoin;
    public int _profilePoint;
    
    public ProfileData ()
    {
        _id = PlayerProfile.profileInstance._profileID;
        _profileName = PlayerProfile.profileInstance._profileName;
        _profileAge = PlayerProfile.profileInstance._profileAge;
        _profileGender = PlayerProfile.profileInstance._profileGender;
        _profileCoin = PlayerProfile.profileInstance._profileCoin;
        _profilePoint = PlayerProfile.profileInstance._profilePoint;
    }

}
