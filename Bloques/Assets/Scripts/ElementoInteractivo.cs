using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementoInteractivo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool pulsado;
    public void OnPointerDown(PointerEventData eventData)
    {
        pulsado = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pulsado = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
