using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoShow : MonoBehaviour
{
    public MiniBase miniBase;
    public Image[] vidas;

    public void Show()
    {
        int v = miniBase.GetVidas();
        for (int i = 1; i <= 4; ++i)
        {
            if (i <= v)
            {
                Debug.Log("Enabling: " + i);
                vidas[i - 1].enabled = true;
            }
        }
    }
    public void Hide()
    {
        for (int i = 1; i <= 4; ++i)
        {
            Debug.Log("Disabling: " + i);
            vidas[i - 1].enabled = false;
        }
    }
}
