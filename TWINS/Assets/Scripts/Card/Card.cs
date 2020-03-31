using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    private bool clicked = false;
    private Rigidbody rigidbody;
    void Awake() {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void update() {

    }

    void OnMouseDown() {
        if (!clicked) {
            clicked = true;
            rigidbody.AddForce(new Vector3(0, 10, 0) * 20);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (clicked && collision.gameObject.tag == "Tablero") {
            Debug.Log("asd");
            this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, 
                                                                this.gameObject.transform.eulerAngles.y - 180, 
                                                                this.gameObject.transform.eulerAngles.z);
        }
    }
}
