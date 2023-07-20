using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefManager
{
    public static string PLAYERCHECKPOINT = "PLAYERCHECKPOINT";
    public static string PLAYERX = "PLAYERX";
    public static string PLAYERY = "PLAYERY";
    public static string PLAYERZ = "PLAYERZ";
    public static int PlayerCheckPoint
    {
        get
        {
            return PlayerPrefs.GetInt(PLAYERCHECKPOINT, 0);
        }
        set
        {
            PlayerPrefs.SetInt(PLAYERCHECKPOINT, value);
        }
    }
}
public struct PlayerPosition
{
    public static void SavePlayerPosition(Vector3 position)
    {
        PlayerPrefs.SetFloat(PrefManager.PLAYERX, position.x);
        PlayerPrefs.SetFloat(PrefManager.PLAYERY, position.y);
        PlayerPrefs.SetFloat(PrefManager.PLAYERZ, position.z);
    }

    public static Vector3 GetPlayerPosition(Vector3 defaultPosition)
    {
        Vector3 Pos = new Vector3();
        Pos.x = PlayerPrefs.GetFloat(PrefManager.PLAYERX, defaultPosition.x);
        Pos.y = PlayerPrefs.GetFloat(PrefManager.PLAYERY, defaultPosition.y);
        Pos.z = PlayerPrefs.GetFloat(PrefManager.PLAYERZ, defaultPosition.z);
        return Pos;
    }
}