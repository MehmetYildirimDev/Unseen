using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public GameObject InfoPanel;

    private void Start()
    {
        MenuManager.IsInitialised = false;
        InfoPanel.SetActive(false);
    }

    public void OnClick_Settings()
    {
        MenuManager.OpenMenu(Menu.SETTINGS, gameObject);
    }

    public void OnClick_Shop()
    {
        MenuManager.OpenMenu(Menu.SHOP, gameObject);
    }

    public void OnClick_Play()
    {
        SceneManager.LoadScene("LevelSelection");
    }


    public List<Text> texts = new List<Text>();
    public void Onclick_Info()
    {
        if (InfoPanel.activeSelf == true)
        {
            InfoPanel.SetActive(false);

            return;
        }
        //TODO: firebaseden verileri oku

        for (int i = 0; i < FirebaseManager.instance.data.Count; i++)
        {
            texts[i].text = FirebaseManager.instance.data[i];
        }

        InfoPanel.SetActive(true);
    }

    public void onClick_Exit()
    {
        Application.Quit();
    }

}
