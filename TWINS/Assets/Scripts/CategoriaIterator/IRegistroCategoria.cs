using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRegistroCategoria
{
    void InsertarCategoria(string categoria);
    string MostrarInformacionCategoria(int indice);
    IIteratorCategoria ObtenerIterator();
}
