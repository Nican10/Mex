using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSegue : MonoBehaviour
{
    public Transform jogador;
   
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(jogador.position.x, jogador.position.y, -10);
    }
}
