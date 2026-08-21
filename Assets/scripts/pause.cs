using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject pausePanel;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        } 
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("saiu");
    }
}
