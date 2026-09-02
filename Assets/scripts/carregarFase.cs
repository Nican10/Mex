using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class carregarFase : MonoBehaviour
{
    public void CarregarFase(string nomeDaFase)
    {
        gameManager.instance.ResetarJogo();
        SceneManager.LoadScene(nomeDaFase);
    }

    public void Voltar()
    {
        SceneManager.LoadScene("menu");
    }
}
