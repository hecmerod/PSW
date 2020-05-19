using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    public Vector3 startPosition, startDistance;

    private Rigidbody rigidbody;
    private GameObject marco;
    private bool showMarco = true;

    private bool dragging;
    private float distance;

    private Elegidas elegidas;

    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        marco = this.gameObject.transform.GetChild(1).gameObject;

        elegidas = FindObjectOfType<Elegidas>();

        startPosition = this.transform.position;
    }

    private void Update() {

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, 0.2f, rayPoint.z);
            
        }
    }

    private void OnMouseDown() {
        dragging = true; showMarco = false;

        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    private void OnMouseUp() {
        dragging = false;

        if (Input.mousePosition.x <= Screen.width * 0.27f) {
            Vector3 aux = elegidas.ReturnPos();

            if ( aux != Vector3.zero) transform.position = aux;
            else transform.position = startPosition;

        } else transform.position = startPosition;
        
    }

    private void OnMouseOver() { marco.SetActive(showMarco); }
    private void OnMouseExit() { marco.SetActive(false); }
}
