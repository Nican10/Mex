using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject restartButton;

    public void MostrarGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void DesativarRestart()
    {
        restartButton.SetActive(false);         
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        gameManager.instance.RestaurarScoreInicioDaFase();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Sair()
    {
        Debug.Log("cliquei no giveup");
        SceneManager.LoadScene("menu");
      
    }
}
