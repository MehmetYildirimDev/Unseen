using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
    //public static bool IsInitialised { get; private set;}
    public static bool IsInitialised;
    public static GameObject mainMenu, settingsMenu, ShopMenu;
    public static void Init()
    {
        GameObject SafeArea = GameObject.Find("SafeArea");//safearea = canvas
        mainMenu = SafeArea.transform.Find("MainMenu").gameObject;
        settingsMenu = SafeArea.transform.Find("SettingsMenu").gameObject;
        ShopMenu = SafeArea.transform.Find("ShopMenu").gameObject;

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
