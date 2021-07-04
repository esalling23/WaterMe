using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppManager
{
    #region Fields
    static float today_consumed = 0f;
    static float daily_goal = 80f;

    #endregion

    #region Properties

    public static float TodayConsumed
    {
        get { return today_consumed; }
    }

    public static float DailyGoal
    {
        get { return daily_goal; }
    }

    public static bool MetGoal
    {
        get { return TodayConsumed >= DailyGoal; }
    }

    #endregion

    #region Methods

    public static void Init()
    {
        // TO DO: Load stored data
        LoadData();
    }

    public static void DrinkWater(float amount)
    {
        // TO DO: Update stored data
        today_consumed += amount;
        SaveSystem.SaveData();
    }

    public static void UpdateGoal(float goal)
    {
        // TO DO: Update stored data
        daily_goal = goal;
        SaveSystem.SaveData();
    }

    public static void LoadData()
    {
        UserData data = SaveSystem.LoadData();

        if (data != null)
        {
            daily_goal = data.current_goal;
            today_consumed = data.today_consumed;
        }
        else
        {
            Debug.Log("No data to load");
        }
    }

    #endregion
}
