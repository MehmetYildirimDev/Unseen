using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplateController : MonoBehaviour
{
    public void LevelComplate()
    {
        if (PlayerPrefs.GetInt("LevelIndex") <= SceneManager.GetActiveScene().buildIndex)
        {
            LevelManager.instance.SaveActiveLevelIndex();
        }

        if (SceneManager.GetActiveScene().buildIndex + 1< SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Scene finish");
        }


    }



}
