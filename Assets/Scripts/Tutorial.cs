using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tutorial : MonoBehaviour
{
    // VARIABLES logicas
    GameController gc;
    AudioManager am;
    public TutorialAnimator animator;
    

    // UI elements
    public Text titulo;
    public Image check;

    public bool win = false;        // Indica si se ha completado el tutorial

    public Draggable pieza;         // Pieza del reloj de arena


    void Start()
    {
        titulo.enabled = false;
        check.enabled = false;
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
            am.Win();
            win = true;
            check.enabled = true;
            animator.Animate();
        }

    }


    public void EndTutorial()
    {
        Debug.Log("Tutorial Complete!");
        am.MusicaJuego();
        gc.LoadNext();
    }
}