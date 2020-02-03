using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialAnimator : MonoBehaviour
{
    public float timePreAnim;
    public float timeInterDelay;
    public float timePostAnim;

    public float speed;
    public Tutorial tut;
    public Renderer relojSinTapa;
    public Renderer tapaReloj;
    public GameObject relojAnimable;
    public Transform destino;

    public Image relojUI;
    public Image timerBarEmpty;
    public Image timerBarFull;
    public float timeToFillBar;

    private Renderer relojCompleto;
    private Transform origen;
    private int animFase = 0;   // 0: nothing   1: pre-move     2: move watch   3: inter-delay  4: fill timerBar   5: post-fill

    private float startTime;            // Time when the movement started.
    private float journeyLength;        // Total distance between the markers.
    private float journeyScale;         // Total scale distance between the markers.

    void Start()
    {
        relojUI.enabled = false;
        timerBarEmpty.enabled = false;
        timerBarFull.enabled = false;

        origen = relojAnimable.transform;
        relojCompleto = relojAnimable.GetComponent<Renderer>();
    }

    // Move to the target end position.
    void Update()
    {
        switch (animFase)
        {
            case 1:     // Animation delay
                timePreAnim -= Time.deltaTime;
                if (timePreAnim <= 0)
                {
                    // Preparar la animación (Se anima en Update)
                    startTime = Time.time;      // Keep a note of the time the movement started.
                    journeyLength = Vector3.Distance(origen.position, destino.position);   // Calculate the journey length.
                    journeyScale = Vector3.Distance(origen.localScale, destino.localScale);          // Calculat the journey scaling lenght.
                    animFase = 2;       // Ir a fase 2: Hourglass animation
                }
                break;

            case 2:     // Hourglass animation

                // Moving to destino...
                float distCovered = (Time.time - startTime) * speed;    // Distance moved equals elapsed time times speed..
                float fractionOfJourney = distCovered / journeyLength;  // Fraction of journey completed equals current distance divided by total distance.
                    // Set position as a fraction of the distance between the markers.
                relojAnimable.transform.position = Vector3.Lerp(origen.position, destino.position, fractionOfJourney);

                // Same for Scaling...
                float scaleCovered = (Time.time - startTime) * (speed * 0.04f);
                float fractionOfScaling = scaleCovered / journeyScale;
                relojAnimable.transform.localScale = Vector3.Lerp(origen.localScale, destino.localScale, fractionOfScaling);

                if (relojAnimable.transform.position == destino.position) animFase = 3;
                break;

            case 3:     // Inter Delay
                timeInterDelay -= Time.deltaTime;
                if (timeInterDelay <= 0) 
                {
                    // Prepare for fase 4
                    relojCompleto.enabled = false;
                    relojUI.enabled = true;
                    timerBarEmpty.enabled = true;
                    timerBarFull.enabled = true;
                    startTime = Time.time;
                    animFase = 4;
                }
                    
                break;

            case 4:     // Fill TimerBar
                timerBarFull.fillAmount = (Time.time - startTime) / timeToFillBar;
                if (timerBarFull.fillAmount >= 1) animFase = 5;
                break;
            case 5:
                timePostAnim -= Time.deltaTime;
                if (timePostAnim <= 0) Finish();
                break;
        }
    }

    public void Animate()
    {
        Debug.Log("Animate!");

        // Cambiar piezas por reloj completo
        relojSinTapa.enabled = false;
        tapaReloj.enabled = false;
        relojCompleto.enabled = true;
        
        animFase = 1;       // Ir a fase 1: delay pre-animación
    }

    void Finish()
    {
        tut.EndTutorial();
    }
}
