using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Draggable[] piezas;  // Piezas del puzzle
    MiniBase miniBase;

    void Start()
    {
        miniBase = gameObject.GetComponentInParent<MiniBase>();
    }

    void Update()
    {
        for (int i = 0; i < piezas.Length; ++i)
        {
            if (!piezas[i].guachi) break;
            miniBase.Win();
            Debug.Log("COMPLETADO!");
        }
    }
}
