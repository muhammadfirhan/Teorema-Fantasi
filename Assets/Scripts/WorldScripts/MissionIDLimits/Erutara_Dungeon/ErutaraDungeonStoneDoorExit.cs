using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErutaraDungeonStoneDoorExit : MonoBehaviour
{
    public int missionMinID;
    [SerializeField] private int value;

    public void setQuestLim()
    {
        missionMinID = value;
    }
}
