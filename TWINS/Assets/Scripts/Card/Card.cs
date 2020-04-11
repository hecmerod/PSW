
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool isTurned = false;
    private int number;
    private PartidaEstandar partida;

    private int pairNumber;

    private MeshRenderer dorso;
    private MeshRenderer cara;

    private void Awake() {
        rigidbody = this.GetComponent<Rigidbody>();
        dorso = this.GetComponentsInChildren<MeshRenderer>()[0];
        cara = this.GetComponentsInChildren<MeshRenderer>()[1];
    }

    private void update() {

    }

    private void OnMouseDown() {
        if (!isTurned) {            
            rigidbody.AddForce(new Vector3(0, 10, 0) * 20);
            isTurned = true;

            this.gameObject.transform.rotation = Quaternion.Euler(180, 0, 0);
            partida.CheckPair(number);            
        }
    }

    public bool IsPair(Card card) {
        return this.pairNumber == card.PairNumber;
    }

    async public void TurnCard() {        
        await Task.Delay(1000); // wait for 1 second        
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        isTurned = false;
        //FALTA HACER 
    }

    public int Number { get => number; set => number = value; }
    public int PairNumber { get => pairNumber; set => pairNumber = value; }
    public MeshRenderer Dorso { get => dorso; set => dorso = value; }
    public MeshRenderer Cara { get => cara; set => cara = value; }
    public PartidaEstandar Partida { get => partida; set => partida = value; }
}
