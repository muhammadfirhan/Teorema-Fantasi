using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystemProfile
{
    public static int CountProfiles()
    {
        string path = @Application.persistentDataPath + "/profiledata";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.Log("Folder created");
        }

        DirectoryInfo d = new DirectoryInfo(path);
        FileInfo[] f = d.GetFiles("*", SearchOption.TopDirectoryOnly);
        Debug.Log("Number of profile: " + f.Length);
        return f.Length;
    }

    public static void SaveProfile()
    {
        int numProfile = CountProfiles();
        if (numProfile <= 10)
        {
            int saveProfileID = PlayerProfile.profileInstance._profileID;
            string saveProfileName = "/profiledata/profile" + saveProfileID + ".sdf";
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + saveProfileName;
            FileStream stream = new FileStream(path, FileMode.Create);

            ProfileData data = new ProfileData();
            formatter.Serialize(stream, data);
            stream.Close();
        }
        else
        {
            Debug.Log("Reaches profile limit");
        }
    }

    public static ProfileData LoadProfile(int pValue)
    {
        int loadProfileID = pValue;
        string loadProfileName = "/profiledata/profile" + loadProfileID + ".sdf";
        string path = Application.persistentDataPath + loadProfileName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ProfileData data = formatter.Deserialize(stream) as ProfileData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Profile does not exist");
            return null;
        }
    }

    public static void DeleteProfile(int numID)
    {
        string selectedProfileName = "/profiledata/profile" + numID + ".sdf";
        string path = Application.persistentDataPath + selectedProfileName;
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Profile deletion success");
        }
        else
        {
            Debug.Log("File doesn't exist");
        }
    }
}
