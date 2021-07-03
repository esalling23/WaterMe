using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    InputField goalInput;

    public void HandleGoalUpdateSubmit()
    {
        // TODO: Validation
        float goal = float.Parse(goalInput.text);
        AppManager.UpdateGoal(goal);
        print(AppManager.DailyGoal);
    }

    public void Close()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }
}
