using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Draggable[] piezas;  // Piezas del puzzle
    MiniBase miniBase;
    bool completado = false;

    void Start()
    {
        miniBase = gameObject.GetComponentInParent<MiniBase>();
    }

    void Update()
    {
        if (!completado)
        {
            int done = 0;
            for (int i = 0; i < piezas.Length; ++i)
            {
                if (piezas[i].guachi) ++done;
            }
            if (done == piezas.Length)              // Todas las piezas en sitio -> ganar
            {
                miniBase.Win();
            }
        }
    }
}
