using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string[] minijuegos;

    public void EnterGameplay()
    {
        int random = Random.Range(0, minijuegos.Length);
        SceneManager.LoadScene(minijuegos[random]);
    }
}
