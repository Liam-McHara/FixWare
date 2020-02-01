using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    private Vector3 pos;
    public Button boton;
    public int clicksNecesarios;
    public int clickCounter = 0;
    MiniBase miniBase;
    public bool winCondition = true; // Especifica si el boton es una condicion de victoria
    public bool activateObjectWhenFinish = false;  // Bool para hacer que al llegar a los clicks necesarios se active un gameobject
    public bool deactivateObjectWhenFinish = false;  // Bool para hacer que al llegar a los clicks necesarios se desactive un gameobject
    public GameObject activableObject;  // Objeto que se activara
    public GameObject deactivableObject;  // Objeto que se desactivara
    public GameObject objectMove;

    // Start is called before the first frame update
    void Start()
    {
        miniBase = gameObject.GetComponentInParent<MiniBase>();
        Button btn = boton.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    void Update()
    {
        if (clickCounter >= clicksNecesarios && activateObjectWhenFinish) activableObject.SetActive(true);
        if (clickCounter >= clicksNecesarios && deactivateObjectWhenFinish) deactivableObject.SetActive(false);
        if (clickCounter >= clicksNecesarios && winCondition) miniBase.Win();
    }

    void OnMouseDown()
    {
        pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        objectMove.transform.position = pos;
    }

    void Click()
    {
        ++clickCounter;
    }
}
