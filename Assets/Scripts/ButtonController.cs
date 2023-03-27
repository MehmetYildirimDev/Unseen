using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    private Button levelButton;

    private Text buttonText;
    private GameObject lockIconObject;

    public int buttonValue;

    private bool isComplate;

    private void Start()
    {
        buttonText = transform.GetChild(0).GetComponent<Text>();
        lockIconObject = transform.GetChild(1).gameObject;

        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(LoadSelectedScene);

        buttonValue = int.Parse(buttonText.text);
    }

    public void SetLockState()
    {
        isComplate = true;

        if (isComplate)
        {
            buttonText.text = buttonValue.ToString();
            lockIconObject.SetActive(false);
        }
        else
        {
            buttonText.text = "";
            lockIconObject.SetActive(true);
        }
    }


    public void LoadSelectedScene()
    {
        if (isComplate)
        {
            SceneManager.LoadScene(buttonValue);
        }
    }


}
