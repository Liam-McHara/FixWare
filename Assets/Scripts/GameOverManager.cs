using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Button backButton;
    public Button replayButton;
    GameController gc;
    AudioManager am;
    public Text scoreText;
    public Text topmarkText;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        am.GameOver();
        scoreText.text = "Score: " + gc.victorias;
        topmarkText.text = "TopMark: " + gc.topmark;
    }

    public void GoBack()
    {
        Debug.Log("GoBack!");
        am.Clic();
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        Debug.Log("Replay!");
        am.Clic();
        gc.Replay();
    }
}
