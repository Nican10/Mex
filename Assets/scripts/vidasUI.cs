using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidasUI : MonoBehaviour
{
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    void Update()
    {
        vida1.SetActive(gameManager.instance.vidas >= 1);
        vida2.SetActive(gameManager.instance.vidas >= 2);
        vida3.SetActive(gameManager.instance.vidas >= 3);
    }
}
