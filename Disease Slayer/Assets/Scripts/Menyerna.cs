using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menyerna : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progressText;
    public static bool check = true;
    public void StartingGame(int sceneIndex)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    public void Options()
    {
        Time.timeScale = 0f;
        check = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BacktoOptions()
    {
        Time.timeScale = 0f;
        check = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Backtogame()
    {
        if (check == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            check = true;
            Time.timeScale = 0f;
        }
        else if (check == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            check = false;
            Time.timeScale = 1f;
        }
    }

    public void Backtomain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
