using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicioFase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameManager.instance.EntrarNaFase();    
    }
}
