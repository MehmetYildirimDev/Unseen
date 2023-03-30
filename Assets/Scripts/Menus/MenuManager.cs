using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
    public static bool IsInitialised { get; private set;}
    public static GameObject mainMenu, settingsMenu, levelsMenu;
    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;
        levelsMenu = canvas.transform.Find("LevelsMenu").gameObject;

        IsInitialised = true;
        if (mainMenu != null)
        {
            Debug.Log("main menu null degil");
        }
        else
        {
            Debug.Log("null");
        }
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialised)
            Init();

        switch (menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
                break;
            case Menu.LEVELS:
                levelsMenu.SetActive(true);
                break;
            default:
                break;
        }

        callingMenu.SetActive(false);
    }

}
