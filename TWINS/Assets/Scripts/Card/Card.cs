
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool isTurned = false;
    private int number;
    private Partida partida;

    private int pairNumber;

    private MeshRenderer dorso;
    private MeshRenderer cara;

    private Vector3 initialPosition;

    private void Awake() {
        rigidbody = this.GetComponent<Rigidbody>();
        dorso = this.GetComponentsInChildren<MeshRenderer>()[0];
        cara = this.GetComponentsInChildren<MeshRenderer>()[1];

        initialPosition = gameObject.transform.position;
    }

    private void update() {
    }

    async private void OnMouseDown() {
        if (!isTurned && partida.NumCardsTurned < 2) {  
            isTurned = true;
            partida.NumCardsTurned++;

            rigidbody.AddForce(new Vector3(0, 1, 0) * 176);
            await Task.Delay(200);
            rigidbody.AddTorque(new Vector3(0, 0, 1) * 40);

            ResetTorque();
            partida.CheckPair(number);
        }
    }

    async private void ResetTorque() {
        while (rigidbody.velocity != Vector3.zero) {
            await Task.Delay(40);
            gameObject.transform.position = new Vector3(initialPosition.x,
                                                        gameObject.transform.position.y,
                                                        initialPosition.z);
        }
    }

    public bool IsPair(Card card) {
        return this.pairNumber == card.PairNumber;
    }

    public void TurnCard() {               
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        isTurned = false;
        //FALTA HACER 
     }

    public int Number { get => number; set => number = value; }
    public int PairNumber { get => pairNumber; set => pairNumber = value; }
    public MeshRenderer Dorso { get => dorso; set => dorso = value; }
    public MeshRenderer Cara { get => cara; set => cara = value; }
    public Partida Partida { get => partida; set => partida = value; }
}
