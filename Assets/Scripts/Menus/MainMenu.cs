using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Text goalText;
    [SerializeField]
    Text todayTotalText;
    [SerializeField]
    RectTransform waterObject;
    [SerializeField]
    Text goalMetText;


    // "animation" support
    float maxHeight;

    // MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = waterObject.sizeDelta.y;

        Refresh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Refresh()
    {
        SetWaterHeight();
        SetOverlayText();
    }

    void SetOverlayText()
    {
        goalText.text = AppManager.DailyGoal.ToString() + "oz";
        todayTotalText.text = AppManager.TodayConsumed.ToString() + "oz";
    }

    void SetWaterHeight()
    {
        float newHeight = maxHeight * (AppManager.TodayConsumed / AppManager.DailyGoal);
        waterObject.sizeDelta = new Vector2(waterObject.sizeDelta.x, newHeight);
    }

    public void HandleDrinkBtnClick()
    {
        AppManager.DrinkWater(8f);

        SetOverlayText();

        if (AppManager.MetGoal)
        {
            goalMetText.gameObject.SetActive(true);

            // Support for the last height change
            if (waterObject.sizeDelta.y < maxHeight)
            {
                SetWaterHeight();
            }
        }
        else
        {
            SetWaterHeight();
        }
    }
    public void HandleSettingsBtnClick()
    {
        MenuManager.GoToMenu(MenuName.Settings);
    }

    public void HandleGardenBtnClick()
    {
        MenuManager.GoToMenu(MenuName.Garden);
    }
}
