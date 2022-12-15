using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystemPlayer
{
    public static int CountSaveFiles()
    {
        string path = @Application.persistentDataPath + "/savefile";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.Log("Folder created");
        }
        DirectoryInfo d = new DirectoryInfo(@path);
        FileInfo[] f = d.GetFiles("*", SearchOption.TopDirectoryOnly);
        Debug.Log("Number of save file: " + f.Length);
        return f.Length;
    }

    public static void SavePlayer()
    {
        int numFile = CountSaveFiles();
        if(numFile <= 5)
        {
            int savePlayerID = PlayerTrack.playerInstance._playerID;
            string savePlayerName = "/savefile/file" + savePlayerID + ".sdf";
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + savePlayerName;
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData();
            formatter.Serialize(stream, data);
            stream.Close();
        }
        else
        {
            Debug.Log("Save file failed");
        }
    }

    public static PlayerData LoadPlayer(int pValue)
    {
        int loadPlayerID = pValue;
        string loadPlayerName = "/savefile/file" + loadPlayerID + ".sdf";
        string path = Application.persistentDataPath + loadPlayerName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file does not exist");
            return null;
        }
    }
}
