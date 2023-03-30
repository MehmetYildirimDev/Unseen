using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
    public static bool IsInitialised { get; private set;}
    public static GameObject mainMenu, settingsMenu, ShopMenu;
    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;
        ShopMenu = canvas.transform.Find("ShopMenu").gameObject;

        IsInitialised = true;
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
            case Menu.SHOP:
                ShopMenu.SetActive(true);
                break;
            default:
                break;
        }

        callingMenu.SetActive(false);
    }

}
