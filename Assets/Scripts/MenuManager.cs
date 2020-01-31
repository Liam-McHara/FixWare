using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int cantidadDeMinijuegos;

    public void EnterGameplay()
    {
        int random = Random.Range(1, cantidadDeMinijuegos+1);   // Devuelve un valor entre 1 y cantidadDeMinijuegos
        SceneManager.LoadScene("mini"+random);
    }
}
