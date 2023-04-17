using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private GameObject GameOverPanel;

    public static GameOverScript instance;//Singleton yapiyoruz

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        try
        {
            GameOverPanel = GameObject.Find("GameOverPanel");
        }
        catch (System.Exception)
        {

            Debug.Log("GameOverPanel bulunamadi");
        }

        GameOverPanel.SetActive(false);
    }

    public void ShowGameOVerPanel()
    {
        StartCoroutine(WaitAndRun());
    }

    public IEnumerator WaitAndRun()
    {
        yield return new WaitForSeconds(1f);
        GameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
