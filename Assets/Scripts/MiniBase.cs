using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniBase : MonoBehaviour
{
    // VARIABLES logicas
    public GameController gameController;
    public float preTitleTime = 1.0f;
    public float preGameTime = 1.0f;
    float tiempo = 5;        // Tiempo (segundos) para resolver el minijuego (se va reduciendo)
    float tiempoInicial;            // Tiempo (segundos) para resolver el minijuego (guarda el valor inicial)
    public bool win = false;        // Indica si se ha resuelto el minijuego
    public bool fail = false;       // Indica si se ha fallado el minijuego


    // UI elements (timer, win sprite, fail sprite...)
    public Image timerBar;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        tiempo = gameController.tiempo;
        tiempoInicial = tiempo; 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();      // Actualiza el contador y su UI
    }

    void UpdateTimer()  
    {
        if (!win && !fail) tiempo -= Time.deltaTime;    // El tiempo corre mientras no se haya terminado el minijuego
        if (tiempo < 0) Fail();                         // Time's up!

        // Actualizar UI
        timerBar.fillAmount = tiempo / tiempoInicial;
    }

    public void SetTime(float t)
    {
        tiempo = t;
        tiempoInicial = tiempo;
    }

    // para provocar eventos de victoria o derrota desde otros scripts
    public void Win()
    {
        // HAS GANADO!!  ueee
        // aqui se hacen las cositas de cuando se gana (sumar puntos, feedback positivo, pasar al siguiente minijuego...)
        ++gameController.victorias;
        win = true;
    }
    public void Fail()
    {
        // HAS PERDIDO...  buuuu
        // aqui se hacen las cositas de cuando se pierde (perder una vida, feedback negativo, pasar al siguiente minijuego, game over...)
        fail = true;
        --gameController.vidas;
    }
}
