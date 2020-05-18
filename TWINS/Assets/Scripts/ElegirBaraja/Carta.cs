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



    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        marco = this.gameObject.transform.GetChild(1).gameObject;

        startPosition = this.transform.position;
    }

    private void Update() {

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint + startDistance;
            transform.position = new Vector3(0, 1.2f, 0);
        }
    }

    private void OnMouseDown() {
        dragging = true; showMarco = false;
        rigidbody.AddForce(new Vector3(0, 1, 0) * 250);
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDistance = transform.position - rayPoint;
    }

    private void OnMouseUp() {
        dragging = false;
        transform.position = startPosition;
    }

    private void OnMouseOver() { marco.SetActive(showMarco); }
    private void OnMouseExit() { marco.SetActive(false); }
}
