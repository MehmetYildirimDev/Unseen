using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    private Button levelButton;

    [SerializeField]private Text buttonText;
    [SerializeField]private GameObject lockIconObject;

    public int buttonValue;

    private bool isComplate;

    private void Start()
    {

        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(LoadSelectedScene);
    } 

    public void SetLockState()
    {
        isComplate = true;

        if (isComplate)
        {
            buttonText.text = buttonValue.ToString();
            lockIconObject.SetActive(false);
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
