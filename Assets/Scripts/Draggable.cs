using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 screenpoint;
    private Transform initialPosition;
    public Transform target;
    private float minX, maxX, minY, maxY;
    public bool onPlace = false;        // Indica si el objeto esta en su sitio.
    public bool onFailReset = false;    // Indica si volver a posicion inicial en caso de error (NO IMPLEMENTADO)
    public bool guachi = false;         // Indica que has ganado
    public bool requireRelease = true;  // Requerir soltar el mouse para evaluar
    public bool deactivateWhenDone = true;  // Desactiva el draggable cuando se completa;
    public bool draggable = true;  // Define si el objeto se puede mover o no

    void Start()
    {
        initialPosition = this.transform;
        // Define los límites de la posicion sobre Target
        minX = target.position.x - target.localScale.x / 2;
        maxX = target.position.x + target.localScale.x / 2;
        minY = target.position.y - target.localScale.y / 2;
        maxY = target.position.y + target.localScale.y / 2;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x > minX && pos.x < maxX && pos.y > minY && pos.y < maxY)
        {
            onPlace = true;
            if (!requireRelease) Guachi();
        }
        else onPlace = false;
    }

    void OnMouseDown()
    {
        screenpoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }

    void OnMouseDrag()
    {
        if (draggable)
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
            transform.position = currentPos;
        }
    }



    void OnMouseUp()    
    {
        if (onPlace)
        {
            Guachi();   
        }
    }

    void Guachi()   // Puzzle completado!
    {
        Debug.Log("GUACHI! Pieza: "+ this.name);
        guachi = true;
        if (deactivateWhenDone) Destroy(this);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Area")
        {
            Guachi();
        }

    }

}