using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public float current_goal;
    public float today_consumed;
    // public Dictionary<string, object> water_history;

    public UserData()
    {
        current_goal = AppManager.DailyGoal;
        today_consumed = AppManager.TodayConsumed;
        // water_history
    }
}
