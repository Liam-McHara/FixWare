using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Donation : MonoBehaviour
{
    private Vector3 pos;
    public Button boton;
    public int donNecesaria = 1000000;
    public int donAprox = 100000;
    int don = 0;
    public Text counterText;
    public Image treelon;
    MiniBase miniBase;


    // Start is called before the first frame update
    void Start()
    {
        treelon.enabled = false;
        counterText.text = ""+don;
        miniBase = gameObject.GetComponentInParent<MiniBase>();
        Button btn = boton.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }


    void Click()
    {
        don += donAprox - Random.Range(0, 999);

        if (don >= donNecesaria)
        {
            don = donNecesaria;
            treelon.enabled = true;
            miniBase.Win();
        }
        // UI
        counterText.text = "" + don;
    }
}
