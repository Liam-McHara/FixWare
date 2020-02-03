using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tutorial : MonoBehaviour
{
    // VARIABLES logicas
    public AudioSource winSound;
    public TutorialAnimator animator;
    public GameController gameController;

    // UI elements
    public Text titulo;
    public Image check;

    public bool win = false;        // Indica si se ha completado el tutorial

    public Draggable pieza;         // Pieza del reloj de arena


    void Start()
    {
        titulo.enabled = false;
        check.enabled = false;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (!win && pieza.guachi)   // Comprueba si se ha completado el tutorial
        {
            Win();
        }
    }


    public void Win()
    {
        if (!win)      // Verifica que el tutorial no haya finalizado ya
        {
            winSound.Play();
            win = true;
            check.enabled = true;
            animator.Animate();
        }

    }


    public void EndTutorial()
    {
        Debug.Log("Tutorial Complete!");
        gameController.musicaJuego.Play();
        gameController.LoadNext();
    }
}