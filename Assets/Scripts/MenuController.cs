using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    GameController gc;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void PlayButton()
    {
        gc.PlayButton();
    }

    public void ExitButton()
    {
        gc.ExitButton();
    }
}
