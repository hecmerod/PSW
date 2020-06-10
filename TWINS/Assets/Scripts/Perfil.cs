using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Perfil : MonoBehaviour
{
    public Button volver;
    public Text partidas;
    public Text wins;
    public Text niveles;
    public Text score;
    public Text nombre;

    void Start()
    {
        nombre.text = DBManager.getInstance().username;
        partidas.text = DBManager.getInstance().partidasJugadas.ToString();
        wins.text = DBManager.getInstance().partidasGanadas.ToString();
        niveles.text = (DBManager.getInstance().nivel - 1).ToString();
        score.text = DBManager.getInstance().puntuacionTotal.ToString();
    }
    public void volverMetodo()
    {
        SceneManager.LoadScene("PantallaInicio");
    }
}
