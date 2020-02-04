using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // musica
    public AudioSource musicaJuego;
    public AudioSource musicaMenu;
    public AudioSource musicaGameOver;
    public AudioSource musicaBoss;
    
    // sonidos
    public AudioSource sonidoClic;
    public AudioSource sonidoWin;
    public AudioSource sonidoFail;
    public AudioSource sonidoGameOver;


    // ----------------------- FUNCIONES ----------------------------------------------
        
    public void Mute()
    {
        musicaJuego.Stop();
        musicaMenu.Stop();
        musicaGameOver.Stop();
        musicaBoss.Stop();
    }

    // Música
    public void MusicaJuego()
    {
        musicaJuego.Play();
        musicaMenu.Stop();
        musicaGameOver.Stop();
        musicaBoss.Stop();
    }

    public void MusicaMenu()
    {
        musicaJuego.Stop();
        musicaMenu.Play();
        musicaGameOver.Stop();
        musicaBoss.Stop();
    }

    public void MusicaGameOver()
    {
        musicaJuego.Stop();
        musicaMenu.Stop();
        musicaGameOver.Play();
        musicaBoss.Stop();
    }

    public void MusicaBoss()    // (NO USADO)  -  Para futuros niveles más intensos 
    {
        musicaJuego.Stop();
        musicaMenu.Stop();
        musicaGameOver.Stop();
        musicaBoss.Play();
    }

    // Sonidos
    public void GameOver()
    {
        sonidoGameOver.Play();
    }

    public void Clic()
    {
        sonidoClic.Play();
    }

    public void Win()
    {
        sonidoWin.Play();
    }

    public void Fail()
    {
        sonidoFail.Play();
    }

}
