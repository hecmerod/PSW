using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IAnimacionStrategy
{
    void MostrarAnimacion(float tiempo, GameObject animacion, Text miTiempo);
}
