using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class jogar : MonoBehaviour
{ 
    public void Jogar()
    {
        gameManager.instance.ResetarJogo();
        SceneManager.LoadScene("tutorial");
    }
           
}
