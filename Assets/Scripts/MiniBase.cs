﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniBase : MonoBehaviour
{
    // VARIABLES logicas
    public GameController gameController;
    public float preTitleTime = 1.0f;
    public float preGameTime = 1.0f;
    public float preInfoTime = 1.0f;
    public float infoTime = 4.0f;

    public Image telon;
    public Text titulo;
    public Image check;
    public Image cross;

    float tiempo;                   // Tiempo (segundos) para resolver el minijuego (se va reduciendo)
    float tiempoInicial;            // Tiempo (segundos) para resolver el minijuego (guarda el valor inicial)
    public bool win = false;        // Indica si se ha resuelto el minijuego
    public bool fail = false;       // Indica si se ha fallado el minijuego

    bool titleShown = false;
    bool gameStarted = false;
    bool infoShown = false;
    float interTimer = 0.0f;        


    // UI elements (timer, win sprite, fail sprite...)
    public Image timerBar;

    void Start()
    {
        telon.enabled = true;
        titulo.enabled = false;
        check.enabled = false;
        cross.enabled = false;
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
        interTimer += Time.deltaTime;
        // PRE-GAME
        if (!titleShown)
        {
            if (interTimer >= preTitleTime)
            {
                ShowTitle();
                interTimer = 0;
            }
        }
        else if (!gameStarted)
        {
            if (interTimer >= preGameTime)
            {
                StartGame();
            }
        }

        // IN-GAME
        else if (gameStarted)
        {
            if (!win && !fail) tiempo -= Time.deltaTime;    // El tiempo corre mientras no se haya terminado el minijuego
            if (tiempo < 0) Fail();                         // Time's up!

            // Actualizar UI
            timerBar.fillAmount = tiempo / tiempoInicial;
        }

        // POST-GAME
        if (win || fail)
        {
            if (interTimer >= preInfoTime && !infoShown)
            {
                ShowInfo();
                infoShown = true;
                interTimer = 0;
            }
            if (interTimer >= infoTime && infoShown)
            {
                LoadNext();
            }
        }

    }

    public void SetTime(float t)
    {
        tiempo = t;
        tiempoInicial = tiempo;
    }

    void ShowTitle()
    {
        Debug.Log("ShowTitle :D");
        titulo.enabled = true;
        titleShown = true;
    }

    void StartGame()
    {
        Debug.Log("Start Game :D");
        telon.enabled = false;
        gameStarted = true;
    }

    

    // para provocar eventos de victoria o derrota desde otros scripts
    public void Win()
    {
        if (!win && !fail)      // Verifica que el juego no haya finalizado ya
        {
            // HAS GANADO!!  ueee
            // aqui se hacen las cositas de cuando se gana (sumar puntos, feedback positivo, pasar al siguiente minijuego...)
            ++gameController.victorias;
            win = true;
            check.enabled = true;
            Debug.Log("WIN!");
            EndGame();
        }
        
    }
    public void Fail()
    {
        if (!win && !fail)      // Verifica que el juego no haya finalizado ya
        {
            // HAS PERDIDO...  buuuu
            // aqui se hacen las cositas de cuando se pierde (perder una vida, feedback negativo, pasar al siguiente minijuego, game over...)
            fail = true;
            --gameController.vidas;
            cross.enabled = true;
            Debug.Log("Fail!");
            EndGame();
        }
    }

    void EndGame()
    {
        interTimer = 0;
    }

    void ShowInfo()
    {
        Debug.Log("Show info!");
        telon.enabled = true;
        check.enabled = false;
        cross.enabled = false;
        infoShown = true;
    }

    void LoadNext()
    {
        Debug.Log("LOAD NEXT!");
        gameController.LoadNext();
    }
}
