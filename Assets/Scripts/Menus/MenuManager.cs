using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager: MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject settings;
    [SerializeField]
    GameObject garden;

    static MenuManager menuManager;

    public static MenuManager instance
    {
        get {
            if (!menuManager)
            {
                menuManager = FindObjectOfType(typeof(MenuManager)) as MenuManager;

                if (!menuManager)
                {
                    Debug.LogError("There needs to be one active MenuManager script on a GameObject in your scene.");
                }
                else
                {
                    DontDestroyOnLoad(menuManager);
                }
            }

            return menuManager;
        }
    }
    public static void GoToMenu(MenuName menu)
    {
        Debug.Log(menu);
        switch(menu)
        {
            case MenuName.Main:
                instance.mainMenu.SetActive(true);
                instance.mainMenu.GetComponent<MainMenu>().Refresh();

                instance.settings.SetActive(false);
                instance.garden.SetActive(false);
                break;

            case MenuName.Settings:
                instance.settings.SetActive(true);

                instance.mainMenu.SetActive(false);
                instance.garden.SetActive(false);
                break;

            case MenuName.Garden:
                instance.garden.SetActive(true);

                instance.settings.SetActive(false);
                instance.mainMenu.SetActive(false);
                break;

            case MenuName.Welcome:
                SceneManager.LoadScene("WelcomeMenu");
                break;
        }
    }
}
