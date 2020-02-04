using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int vidas;
    public int victorias;
    public float tiempo;        // tiempo disponible para resolver los minijuegos
    public int nivel = 0;
    public int victPorNivel;    // Cantidad de victorias para subir de nivel (se reduce el tiempo disponible) según la siguiente función:
                                //      0.89^(x-12)+('tiempo'-4)       http://www.mathsisfun.com/data/function-grapher.php?func1=0.89%5E(x-12)%2B2&xmin=-2.867&xmax=13.64&ymin=-2.042&ymax=8.160

    int vidInicial;
    int victInicial;
    public int topmark;     // mejor puntuación

    float tiemInicial;
    public int[] lastPlayed;       // Guarda los indices de los ultimos minijuegos jugados
    int lastIndex;          // Guarda el último indice del array lastPlayed, para alternar de uno a otro.

    // AUDIO
    public AudioManager am;

    public int cantidadDeMinijuegos;
    int noRepetir = 6;      // ATENCION: Al cambiar este valor hay que modificar la selección semi-aleatoria de minijuego.

    public bool tutorialFirst;
    //FOR TESTING
    public bool loadOverride;
    public int loadThis;

    void Start()
    {
        vidInicial = vidas;
        tiemInicial = tiempo;
        topmark = 0;
    }

    public void PlayButton()
    {
        am.Clic();
        if (tutorialFirst) StartTutorial();
        else StartGame();
    }

    public void StartTutorial()
    {
        Debug.Log("Starting Tutorial...");
        am.Mute();
        SceneManager.LoadScene("Tutorial");
        lastPlayed = new int[noRepetir];
    }

    public void StartGame()
    {
        int load;                   // Indice del minijuego a cargar...
        if (loadOverride) load = loadThis;                      // Fijado o
        else load = Random.Range(1, cantidadDeMinijuegos + 1);  // aleatorio
        lastPlayed = new int[noRepetir];    
        lastPlayed[0] = load;
        for (int i = 1; i<noRepetir; ++i)
        {
            lastPlayed[i] = 0;
        }

        am.MusicaJuego();
        SceneManager.LoadScene("mini" + load);
    }

    public void LoadNext()  // Carga el siguiente minijuego, comprobando que no se repitan los "noRepetir" últimos
    {
        // Asignación del tiempo disponible
        nivel = victorias / victPorNivel;
        tiempo = Mathf.Pow(0.89f, (nivel - 12)) + (tiemInicial - 4);

        // Seleccion semi-aleatorioa de minijuego
        int random = Random.Range(1, cantidadDeMinijuegos + 1);     // Selecciona uno aleatorio
        
        while (random == lastPlayed[0] || random == lastPlayed[1]   // Comprueba que no se repita el minijuego
            || random == lastPlayed[2] || random == lastPlayed[3] 
            || random == lastPlayed[4] || random == lastPlayed[5])
        {
            random = Random.Range(1, cantidadDeMinijuegos + 1);
        }

        // Guarda el nuevo índice para no repetir minijuego
        if (lastIndex == noRepetir-1)
        {
            lastPlayed[0] = random;
            lastIndex = 0;
        }
        else
        {
            lastPlayed[lastIndex+1] = random;
            ++lastIndex;
        }

        // Carga la siguiente escena
        SceneManager.LoadScene("mini" + random);
    }

    public void Fail()
    {
        Debug.Log("Fail...");
        am.Fail();
        --vidas;
        if (vidas <= 0) GameOver();
    }

    public void Win()
    {
        Debug.Log("WIN!");
        am.Win();
        ++victorias;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        am.MusicaGameOver();
        SceneManager.LoadScene("GameOverScene");
        if (victorias > topmark) topmark = victorias;

        // Restaurar valores iniciales
        vidas = vidInicial;
        tiempo = tiemInicial;
    }
    
    public void ExitButton()
    {
        Debug.Log("Bye Bye");
        am.Clic();
        Application.Quit();
    }
    
    public void Replay()        // Empieza una nueva partida
    {
        victorias = 0;
        tiempo = tiemInicial;
        am.MusicaJuego();
        LoadNext();
    }
}

/* CODIGO EXPLOSIVO PARA ENCONTRAR MINIJUEGO NO REPETIDO
        int random = 1; 
        bool encontrado = false;
        while (!encontrado)
        {
            random = Random.Range(1, cantidadDeMinijuegos + 1); // selecciona minijuego al azar
            Debug.Log("Probando con "+random);
            for (int i = 0; i < noRepetir; ++i)                 // y mira la lista...
            {
                Debug.Log("i = "+i);
                //if (random == lastPlayed[i]) break;             // Si se repite, vuelve a empezar.
                if (i == noRepetir-1 && random == lastPlayed[i])   // Si llega al final y no es repetido...
                {
                    encontrado = true;              // Entonces ya ha encontrado el minijuego ("random")
                    Debug.Log("encontrado = true");
                }
            }
            Debug.Log("fin del while");
        }*/
