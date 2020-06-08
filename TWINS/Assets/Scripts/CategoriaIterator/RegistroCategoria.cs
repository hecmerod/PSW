using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistroCategoria : IRegistroCategoria
{
    private List<String> listaCategorias;

    public RegistroCategoria()
    {
        this.listaCategorias = new List<String>();
    }

    public void InsertarCategoria(string categoria)
    {
        listaCategorias.Add(categoria);
    }

    public string MostrarInformacionCategoria(int indice)
    {
        return listaCategorias[indice];
    }

    public IIteratorCategoria ObtenerIterator()
    {
        return new IteratorCategoria(listaCategorias);
    }
}
    
