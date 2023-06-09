using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    [SerializeField] private AudioClip winClip;
    private const int LEVELCOUNT = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            try
            {
                SoundManager.instance.PlaySound(winClip);
            }
            catch (System.Exception)
            {
                print("sound manager yok");
            }

            LevelComplate();
        }
    }

    public void LevelComplate()
    {
        Debug.Log(PlayerPrefs.GetInt("LevelIndex"));
        if (PlayerPrefs.GetInt("LevelIndex") <= SceneManager.GetActiveScene().buildIndex)
        {
           
            LevelManager.instance.SaveActiveLevelIndex();
        }

        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(ShowComplate());
            //bunu bir sure beklesin diye fonsktionun icine aliyorum
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Scene finish");
        }
    }

    private IEnumerator ShowComplate()
    {
        GameManager.instance.ShowLevelComplatePanel();
        yield return new WaitForSeconds(1f);
        
        if (SceneManager.GetActiveScene().buildIndex == LEVELCOUNT)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

}
