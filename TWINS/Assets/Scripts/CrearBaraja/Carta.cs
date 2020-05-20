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

    private bool chosen = false;
    private Vector3 posChosen;

    private GameObject baraja;
    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        marco = this.gameObject.transform.GetChild(1).gameObject;

        baraja = GameObject.Find("Baraja");
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
        showMarco = false;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        
    }
    private void OnSecondaryMouseDown() {

        if (!chosen)
        {
            Vector3 aux = elegidas.ReturnPos();

            if (aux != Vector3.zero)
            {
                transform.parent = baraja.transform;
                transform.position = aux;
                
                posChosen = aux;                
                chosen = true;
            }
        }
        else {
            elegidas.LiberatePos(posChosen);
            transform.position = startPosition;
            transform.parent = null;
            chosen = false;
        }
    }

    private void OnMouseUp() {
        dragging = false;
        if (!chosen) {
            if (Input.mousePosition.x <= Screen.width * 0.27f) {
                Vector3 aux = elegidas.ReturnPos();

                if (aux != Vector3.zero) {
                    transform.parent = baraja.transform;
                    transform.position = aux;                    
                    posChosen = aux;
                    chosen = true;
                } else transform.position = startPosition;               

            } else transform.position = startPosition;
        } 
        else {
             if (Input.mousePosition.x <= Screen.width * 0.27f) {
                transform.position = posChosen;
             } 
             else {
                chosen = false;
                elegidas.LiberatePos(posChosen);
                transform.position = startPosition;
                transform.parent = null;
             }
        }        
    }

    private void OnMouseOver() {        
        marco.SetActive(showMarco);

        if (Input.GetKeyDown(KeyCode.Mouse1)) OnSecondaryMouseDown();
    }
    private void OnMouseExit() { marco.SetActive(false); }
}
