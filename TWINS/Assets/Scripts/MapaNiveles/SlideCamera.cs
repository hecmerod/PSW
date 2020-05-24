using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlideCamera : MonoBehaviour
{
    public float scrollAcceleration, maxSpeed, topBarrier, botBarrier,
                 mapTopBarrier, mapBotBarrier;
    private float scrollSpeed;

    private bool vNiño = false;
    public Button botonNiñoAdulto;

    private void Update() {
        Translation();
    }

    private void Translation() {

        CalculateSpeed();
        if (!vNiño)
        {
            if (Input.mousePosition.y >= Screen.height * topBarrier && transform.position.z < mapTopBarrier)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
            }
            if (Input.mousePosition.y <= Screen.height * botBarrier && transform.position.z > mapBotBarrier)
            {
                transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.World);
            }
        }
        else
        {
            if (Input.mousePosition.y >= Screen.height * topBarrier && transform.position.z > -mapTopBarrier)
            {
                transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.World);
            }
            if (Input.mousePosition.y <= Screen.height * botBarrier && transform.position.z < -mapBotBarrier)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
            }
        }
    }
    private void CalculateSpeed() {
        if (scrollSpeed < maxSpeed
            && (Input.mousePosition.y >= Screen.height * topBarrier ||
                Input.mousePosition.y <= Screen.height * botBarrier))
        {
            scrollSpeed += scrollAcceleration;
        }
        else if (scrollSpeed > 0) scrollSpeed -= 3 * scrollAcceleration;        
    }
    public void VersionNiñoAdulto()
    {
        if (!vNiño)
        {
            this.transform.position = new Vector3(15, 5, 0);
            this.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(60, 180, 0));
            botonNiñoAdulto.image.color = Color.blue;
            vNiño = true;
        }
        else {
            this.transform.position = new Vector3(15, 5, 0);
            this.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(60, 0, 0));
            botonNiñoAdulto.image.color = Color.yellow;
            vNiño = false;
        }
    }
}
