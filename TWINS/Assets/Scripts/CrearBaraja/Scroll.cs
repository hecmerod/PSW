using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollAcceleration, maxSpeed, topBarrier, botBarrier;
    private float scrollSpeed;
    
    void Update()
    {
        CalculateSpeed();
        ScrollElegidas();        
    }

    private void ScrollElegidas() {
        
        if (Input.mousePosition.x > Screen.width * 0.27f) return;

        if (Input.mousePosition.y >= Screen.height * topBarrier && transform.position.z >= -5)
        {
            transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.World);
        }
        if (Input.mousePosition.y <= Screen.height * botBarrier && transform.position.z < 10)
        {            
            transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
        }
    }
    private void CalculateSpeed()
    {
        if (scrollSpeed < maxSpeed
            && (Input.mousePosition.y >= Screen.height * topBarrier ||
                Input.mousePosition.y <= Screen.height * botBarrier))
        {
            scrollSpeed += scrollAcceleration;
        }
        else if (scrollSpeed > 0) scrollSpeed -= 3 * scrollAcceleration;
    }
}
