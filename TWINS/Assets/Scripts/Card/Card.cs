
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

    private MeshRenderer dorso, cara;
    private GameObject marco;
    private bool showMarco = true;
    private Vector3 initialPosition;
    private int cartasAEncontrar;

    AudioSource audioSource;



    private void Awake() {
        if (GameProperties.trios)
        {
            cartasAEncontrar = 3;
        }
        else
        {
            cartasAEncontrar = 2;
        }
        rigidbody = this.GetComponent<Rigidbody>();
        dorso = this.GetComponentsInChildren<MeshRenderer>()[0];
        cara = this.GetComponentsInChildren<MeshRenderer>()[1];

        marco = this.gameObject.transform.GetChild(2).gameObject;

        initialPosition = gameObject.transform.position;

        audioSource = GetComponent<AudioSource>();
    }

    private void update() {
    }

    async private void OnMouseDown() {
        if (!isTurned && partida.NumCardsTurned < cartasAEncontrar) {  
            isTurned = true;
            partida.NumCardsTurned++;

            rigidbody.AddForce(new Vector3(0, 1, 0) * 176);
            showMarco = false;
            await Task.Delay(200);

            rigidbody.AddTorque(new Vector3(0, 0, 1) * 40);
            audioSource.Play();
            while (rigidbody.velocity != Vector3.zero) {
                await Task.Delay(40);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                            gameObject.transform.position.y,
                                                            gameObject.transform.position.z);
            }            
            partida.CheckPair(number);
        }
    }

    private void OnMouseOver() { 
        marco.SetActive(showMarco);
    }
    void OnMouseExit() { marco.SetActive(false); }

    public bool IsPair(Card card) {
        return this.pairNumber == card.PairNumber;
    }

    public void TurnCard() {               
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        isTurned = false;
        showMarco = true;
        //FALTA HACER 
     }

    public int Number { get => number; set => number = value; }
    public int PairNumber { get => pairNumber; set => pairNumber = value; }
    public MeshRenderer Dorso { get => dorso; set => dorso = value; }
    public MeshRenderer Cara { get => cara; set => cara = value; }
    public Partida Partida { get => partida; set => partida = value; }
}
