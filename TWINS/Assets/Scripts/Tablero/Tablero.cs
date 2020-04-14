using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    [SerializeField] private Vector3[] positionCards;

    
    private Baraja baraja;
    private ArrayList cards = new ArrayList();
    private PartidaEstandar partida;


    public Tablero(PartidaEstandar partida, Vector3[] positionCards, string tematica) {
        //WIDTH
        //HEIGHT
        this.partida = partida;
        this.positionCards = positionCards;

        GameObject.Instantiate(partida.Tablero, new Vector3(7.5f, 0, 5), Quaternion.identity);

        baraja = CreadorBaraja.CrearBaraja("animal", this);
    }

    public Vector3[] PositionCards { get => positionCards; set => positionCards = value; }
    public Baraja Baraja { get => baraja; set => baraja = value; }
}
