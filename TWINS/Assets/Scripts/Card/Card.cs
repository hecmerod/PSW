using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool isTurned = false;
    private int number;
    private Tablero tablero;

    private int pairNumber;

    private MeshRenderer dorso;
    private MeshRenderer cara;

    void Awake() {
        rigidbody = this.GetComponent<Rigidbody>();
        dorso = this.GetComponentsInChildren<MeshRenderer>()[0];
        cara = this.GetComponentsInChildren<MeshRenderer>()[1];
    }

    void update() {

    }

    void OnMouseDown() {
        if (!isTurned) {            
            rigidbody.AddForce(new Vector3(0, 10, 0) * 20);
            isTurned = true;

            tablero.CheckPair(number);
            this.gameObject.transform.rotation = Quaternion.Euler(180, 0, 0);
        }
    }

    public bool IsPair(Card card) {
        return this.pairNumber == card.PairNumber;
    }

    public void TurnCard() {
        isTurned = false;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //FALTA HACER 
    }

    public int Number { get => number; set => number = value; }
    public Tablero Tablero { get => tablero; set => tablero = value; }
    public int PairNumber { get => pairNumber; set => pairNumber = value; }
    public MeshRenderer Dorso { get => dorso; set => dorso = value; }
    public MeshRenderer Cara { get => cara; set => cara = value; }
}
