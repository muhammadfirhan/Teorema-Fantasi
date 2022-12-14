using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerProfile : MonoBehaviour
{
    public static PlayerProfile profileInstance;
    public string playerName;
    public int playerAge;

    private void Awake()
    {
        profileInstance = this;
        DontDestroyOnLoad(gameObject);
    }
}
