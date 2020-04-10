using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool isTurned = false;
    private int number;
    public Tablero tablero;

    private int pairNumber;

    void Awake() {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void update() {

    }

    void OnMouseDown() {
        if (!isTurned) {            
            rigidbody.AddForce(new Vector3(0, 10, 0) * 20);
            isTurned = true;

            tablero.CheckPair(number);
        }
    }

    public bool IsPair(Card card) {
        return this.pairNumber == card.PairNumber;
    }

    public void TurnCard() {
        isTurned = false;
        //FALTA HACER 
    }

    public int Number { get => number; set => number = value; }
    public Tablero Tablero { get => tablero; set => tablero = value; }
    public int PairNumber { get => pairNumber; set => pairNumber = value; }
}
