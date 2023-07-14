using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject GameOverPanel;
    private GameObject LevelComplatePanel;
    private GameObject PausePanel;
    private GameObject PauseButton;
    private Button RestartButton;

    public static GameManager instance;//Singleton yapiyoruz

    public GameObject GamePanelPrefab;
    private GameObject Canvas;


    private bool gameOverCalled = false;
    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        print(SceneManager.GetActiveScene().buildIndex);

        try
        {
            Canvas = GameObject.Find("Canvas");
            GameOverPanel = GameObject.Find("GameOverPanel");
            LevelComplatePanel = GameObject.Find("LevelComplatePanel");
            PausePanel = GameObject.Find("PausePanel");
            PauseButton = GameObject.Find("PauseButton");
            RestartButton = PausePanel.transform.Find("RestartButton").GetComponent<Button>();
        }
        catch (System.Exception)
        {

            Debug.Log("GameOverPanel or Canvas bulunamadi");
        }

        GameOverPanel.SetActive(false);
        LevelComplatePanel.SetActive(false);
        PausePanel.SetActive(false);

        CreateLevelNumberText();

        RestartButton.onClick.AddListener(RestartLevel);
    }



    private void Update()
    {
        if (PlayerController.instance.isGameOver && !gameOverCalled)
        {
            onGameOver();
        }
    }

    private void onGameOver()
    {
        try
        {
            SoundManager.instance.PlayGameOverSound();
        }
        catch (System.Exception)
        {
            print("sound manager yok");
        }
        
        gameOverCalled = true;
    }

    private void CreateLevelNumberText()
    {

        GameObject GamePanel = Instantiate(GamePanelPrefab, Canvas.transform.position, Quaternion.identity, Canvas.transform.GetChild(0).transform);
        GamePanel.transform.GetChild(0).GetComponent<Text>().text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();


    }

    public void ShowGameOVerPanel()
    {
        StartCoroutine(WaitAndRunGameOverPanel());
        
    }

    private IEnumerator WaitAndRunGameOverPanel()
    {
        yield return new WaitForSeconds(1f);
        PauseButton.SetActive(false);
        GameOverPanel.SetActive(true);
        GetComponent<AdMobInterstitial>().ShowAD_Interstitial();
    }

    public void ShowLevelComplatePanel()
    {
        LevelComplatePanel.SetActive(true);

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseButtonOnclick()
    {
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void ContinueButtonOnclick()
    {
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        if (PauseButton != null)
        {
            PauseButton.SetActive(true);
        }
        Time.timeScale = 1;

    }
}
