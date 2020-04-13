using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IAnimacion
{
    void MostrarAnimacion(float tiempo, GameObject miCanvas, GameObject animacion, Text miTiempo);
}
