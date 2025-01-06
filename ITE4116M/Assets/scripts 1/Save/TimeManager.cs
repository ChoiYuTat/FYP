using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static float oriT;
    public static float curT;

    public static void SetOriTime()
    {
        float tempT = Time.realtimeSinceStartup;
        oriT= Savedata.Instance.gameTime- tempT;
        SetCurTime();
    }

    public static void SetCurTime()
    {
        curT = Mathf.Max(TimeManager.oriT + Time.realtimeSinceStartup, 0);
        Savedata.Instance.gameTime = curT;
    }

    public static string GetFormatTime(int seconds)
    {
        TimeSpan ts = new TimeSpan(0,0,seconds);
        return $"{ts.Hours.ToString("00")}:{ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")}";
    }

    public static void SetDate(ref string date)
    {
        date = date.Insert(4, "/");
        date= date.Insert(7, "/");

    }

    public static void SetTime(ref string time)
    {
        time=time.Insert(2, "/");
        time=time.Insert(5, "/");
    }
}
