using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IteratorCategoria : IIteratorCategoria
{
    private List<String> categorias;
    string categoria;
    private int posicionActual = 0;

    public IteratorCategoria(List<String> listado)
    {
        this.categorias = listado;
    }

    public void Primero()
    {
        this.posicionActual = 0;
    }
    public String Actual()
    {
        if((this.categorias == null) || 
            (this.categorias.Count == 0) ||
            (posicionActual > this.categorias.Count - 1) ||
            (this.posicionActual < 0))
        {
            throw new ArgumentOutOfRangeException();
        }
        else
        {
            return this.categorias[posicionActual];
        }
    }

    public String Siguiente()
    {
        if (categorias.Count > 1) { categorias.RemoveAt(posicionActual); }
        if ((this.categorias == null) ||
            (this.categorias.Count == 0) ||
            (posicionActual + 1 > this.categorias.Count - 1))
        {
            throw new ArgumentOutOfRangeException();
        }

        else
        {
            return this.categorias[++posicionActual];
        }
    }

    public String Aleatorio()
    {
        posicionActual = Random.Range(0, categorias.Count);

        categoria = this.categorias[posicionActual];
        if (categorias.Count > 1) { categorias.RemoveAt(posicionActual); }
        return categoria;
    }

    public bool QuedanElementos()
    {
        return (posicionActual + 1 <= this.categorias.Count - 1);
    }
}
