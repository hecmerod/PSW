﻿using System.Collections;
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
        switch (GameProperties.getInstance().tipoPartida)
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
            case "Dinamica":
                Partida = new Dinamica();
                ((Dinamica)Partida).Awake();
                ((Dinamica)Partida).Start();
                break;
            case "MultiLocal":
                Partida = new MultijugadorLocal();
                ((MultijugadorLocal)Partida).Awake();
                ((MultijugadorLocal)Partida).Start();
                break;
        }
    }

    public Partida Partida { get => partida; set => partida = value; }
}
