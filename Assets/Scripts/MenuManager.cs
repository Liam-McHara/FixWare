using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int cantidadDeMinijuegos;

    //FOR TESTING
    public int loadThis;            
    public bool loadOverride;

    public void EnterGameplay()
    {
        if (loadOverride) SceneManager.LoadScene("mini" + loadThis);
        else
        {
            int random = Random.Range(1, cantidadDeMinijuegos + 1);   // Devuelve un valor entre 1 y cantidadDeMinijuegos
            SceneManager.LoadScene("mini" + random);
        }
    }
}
