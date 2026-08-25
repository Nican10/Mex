using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int vidas = 3;
    public int score = 0;
    public int scoreInicioDaFase = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void ResetarJogo()
    {
        vidas = 3;
        score = 0;
    }
    public void RestaurarScoreInicioDaFase()
    {
        score = scoreInicioDaFase;
    }

    public void EntrarNaFase()
    {
        scoreInicioDaFase = score;
    }
    
}
