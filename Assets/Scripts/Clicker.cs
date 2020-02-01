using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public Button boton;
    public int clicksNecesarios;
    public int clickCounter = 0;
    MiniBase miniBase;

    // Start is called before the first frame update
    void Start()
    {
        miniBase = gameObject.GetComponentInParent<MiniBase>();
        Button btn = boton.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    void Update()
    {
        if (clickCounter >= clicksNecesarios) miniBase.Win();
    }

    void Click()
    {
        ++clickCounter;
    }
}
