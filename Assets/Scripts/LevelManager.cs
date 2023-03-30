using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject Buttons;

     private List<GameObject> buttonList = new List<GameObject>();

    private int activeLevelIndex = 1;

    public static LevelManager instance;//Singleton yapiyoz

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

    }



    private void Start()
    {  
        AddButtoontoList();
        LoadComplateLevels();
        CheckAllButton();
    }

    private void AddButtoontoList()
    {
        for (int i = 0; i < Buttons.transform.childCount; i++)
        {
            buttonList.Add(Buttons.transform.GetChild(i).gameObject);
        }
    }

    private void CheckAllButton()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (activeLevelIndex >= buttonList[i].GetComponent<ButtonController>().buttonValue)
            {
                buttonList[i].GetComponent<ButtonController>().SetLockState();
            }
        }
    }

    private void LoadComplateLevels()   
    {
        if (PlayerPrefs.GetInt("LevelIndex") == 0)
        {
            activeLevelIndex = 1;
        }
        else
        {
            activeLevelIndex = PlayerPrefs.GetInt("LevelIndex");
        }
    }

    public void SaveActiveLevelIndex()//complete oldugunda
    {
        activeLevelIndex++;
        PlayerPrefs.SetInt("LevelIndex", activeLevelIndex);
    }

    [ContextMenu("Clear")]
    public void ClearP()
    {
        PlayerPrefs.DeleteKey("LevelIndex");
    }
}
