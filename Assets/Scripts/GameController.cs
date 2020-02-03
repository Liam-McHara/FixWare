using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int vidas;
    public int victorias;
    public float tiempo;    // tiempo disponible para resolver los minijuegos

    int vidInicial;
    int victInicial;
    public int topmark;     // mejor puntuación

    float tiemInicial;
    int[] lastPlayed;       // Guarda los indices de los ultimos minijuegos jugados
    int lastIndex;          // Guarda el último indice del array lastPlayed, para alternar de uno a otro.

    public AudioSource musicaFondo;

    //public GameObject notNoobFlag;  // Se crea la primera vez que el jugador pulsa "Play". 
    //     Sirve para personalizar la primera partida y para evitar que se generen múltiples GameControllers.

    public bool tutorialFirst;

    public int cantidadDeMinijuegos;
    //FOR TESTING
    public int loadThis;
    public bool loadOverride;
    


    void Start()
    {
        vidInicial = vidas;
        tiemInicial = tiempo;
        topmark = 0;
       /* GameObject flag = GameObject.FindWithTag("NotANoob");
        if (flag != null)    // Evitar generación de múltiples GameControllers
        {
            Debug.Log("NOT A NOOB");
            Destroy(this);
        }*/
    }

    public void PlayButton()
    {
        if (tutorialFirst) StartTutorial();
        else StartGame();
    }

    public void StartTutorial()
    {
        Debug.Log("Starting Tutorial...");
        SceneManager.LoadScene("Tutorial");
        lastPlayed = new int[] { 0, 0 };
    }

    public void StartGame()
    {
        int load;
        if (loadOverride) load = loadThis;
        else
        {
            int random = Random.Range(1, cantidadDeMinijuegos + 1);   // Devuelve un valor entre 1 y cantidadDeMinijuegos
            load = random;
        }
        lastPlayed = new int[] { load, load };

        // LOAD SCENE
        /*
        GameObject flag = GameObject.FindWithTag("NotANoob");
        if (flag == null)    // For the first time...
        {
            Instantiate(notNoobFlag, this.transform);
            
        }
        else
        {

        }*/

        
        musicaFondo.Play();
        SceneManager.LoadScene("mini" + load);
    }

    public void LoadNext()  // Carga el siguiente minijuego, comprobando que no se repitan los 2 ultimos
    {
        int random = Random.Range(1, cantidadDeMinijuegos + 1); // Selecciona uno aleatorio
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
        // Carga la siguiente escena
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
        SceneManager.LoadScene("GameOverScene");
        if (victorias > topmark) topmark = victorias;

        // Restaurar valores iniciales
        vidas = vidInicial;
        tiempo = tiemInicial;
    }
    
    public void Exit()
    {
        Debug.Log("Bye Bye");
        Application.Quit();
    }
    
    public void Replay()
    {
        victorias = 0;
        LoadNext();
    }
}
