using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Button backButton;
    public Button replayButton;
    public GameController gc;
    public Text scoreText;
    public Text topmarkText;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        gc.musicaJuego.Stop();
        //gc.musicaMenu.Play();
        scoreText.text = "Score: " + gc.victorias;
        topmarkText.text = "TopMark: " + gc.topmark;
    }

    public void GoBack()
    {
        Debug.Log("GoBack!");
        gc.sonidoClic.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        Debug.Log("Replay!");
        gc.sonidoClic.Play();
        gc.Replay();
    }

    public void Exit()
    {

    }
}
