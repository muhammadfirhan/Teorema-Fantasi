using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsToggleComponent : MonoBehaviour
{
    public Image imageOn;
    public Image imageOff;
    
    public void Toggle_Changed(bool value)
    {
        if(value == true)
        {
            imageOn.enabled = true;
            imageOff.enabled = false;
        }else if(value == false)
        {
            imageOn.enabled = false;
            imageOff.enabled = true;
        }
    }
}
