using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPartida : MonoBehaviour
{   
    private Partida partida;
    
    void Awake() {
        CreatePartida();
    }

    protected void Update()
    {
        partida.Update();
    }

    private void CreatePartida() {
        switch (GameProperties.tipoPartida)
        {
            case "PartidaEstandar":
                Partida = new PartidaEstandar();
                ((PartidaEstandar)Partida).Awake();
                ((PartidaEstandar)Partida).Start();
                break;
            case "PartidaPorCarta":
                Partida = new PartidaPorCarta();
                ((PartidaPorCarta)Partida).Awake();
                ((PartidaPorCarta)Partida).Start();
                break;
            case "PartidaPorCategoria":
                Partida = new PartidaPorCategoria();
                ((PartidaPorCategoria)Partida).Awake();
                ((PartidaPorCategoria)Partida).Start();
                break;
            case "Trios":
                Partida = new Trios();
                ((Trios)Partida).Awake();
                ((Trios)Partida).Start();
                break;
        }
    }

    public Partida Partida { get => partida; set => partida = value; }
}
