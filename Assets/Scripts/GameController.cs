using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int vidas;
    public int victorias;
    public float tiempo;    // tiempo disponible para resolver los minijuegos

    int vidInicial;
    int victInicial;
    float tiemInicial;
    public int[] lastPlayed;    // Guarda los indices de los ultimos minijuegos jugados
    int lastIndex;      // guarda el último indice del array lastPlayed, para alternar de uno a otro.

    public int cantidadDeMinijuegos;

    //FOR TESTING
    public int loadThis;
    public bool loadOverride;

    public void EnterGameplay()
    {
        int load;
        if (loadOverride) load = loadThis;
        else
        {
            int random = Random.Range(1, cantidadDeMinijuegos + 1);   // Devuelve un valor entre 1 y cantidadDeMinijuegos
            load = random;
        }
        lastPlayed = new int[] { load, load };
        SceneManager.LoadScene("mini" + load);
    }

    public void LoadNext()  // Carga el siguiente minijuego, comprobando que no se repitan los 2 ultimos
    {
        int random = Random.Range(1, cantidadDeMinijuegos + 1);
        if (lastIndex == 0)
        {
            while (random == lastPlayed[0] || random == lastPlayed[1])  // Comprueba que no se repita el minijuego
            {
                random = Random.Range(1, cantidadDeMinijuegos + 1); 
            }

            lastPlayed[1] = random;     // Guarda el nuevo índice para no repetir minijuego
            lastIndex = 1;
        }
        else
        {
            while (random == lastPlayed[0] || random == lastPlayed[1]) random = Random.Range(1, cantidadDeMinijuegos + 1);
            lastPlayed[0] = random;
            lastIndex = 0;
        }

        SceneManager.LoadScene("mini" + random);
    }

    public void Fail()
    {
        Debug.Log("Fail...");
        --vidas;
        if (vidas <= 0) GameOver();
    }

    public void Win()
    {
        Debug.Log("WIN!");
        ++victorias;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("MainMenu");
    }
}
