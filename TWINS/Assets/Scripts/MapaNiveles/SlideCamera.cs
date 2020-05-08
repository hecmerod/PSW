using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideCamera : MonoBehaviour
{
    public float scrollAcceleration, maxSpeed, topBarrier, botBarrier,
                 mapTopBarrier, mapBotBarrier;
    private float scrollSpeed;

    private void Update() {
        Translation();
    }

    private void Translation() {

        CalculateSpeed();

        if (Input.mousePosition.y >= Screen.height * topBarrier && transform.position.z < mapTopBarrier)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
        }
        if (Input.mousePosition.y <= Screen.height * botBarrier && transform.position.z > mapBotBarrier)
        {
            transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.World);
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
}
