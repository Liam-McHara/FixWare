using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTitle : MonoBehaviour
{
    public Text titulo;
    public MiniBase miniBase;
    public string tituloSinLetra;
    bool cambiado = false;

    
    void Update()
    {
        if (!cambiado && miniBase.gameStarted == true)
        {
            Debug.Log("Cambiando a: " + tituloSinLetra);
            titulo.text = tituloSinLetra;
            cambiado = true;
        }
    }
}
