using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsMenu : MonoBehaviour
{
    public void OnClick_Back()
    {
       MenuManager.OpenMenu(Menu.MAIN_MENU, gameObject);
    }

    
}
