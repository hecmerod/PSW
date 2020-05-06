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
    // Start is called before the first frame update
    void Start()
    {
        nombre.text = DBManager.username;
        partidas.text = DBManager.partidasJugadas.ToString();
        wins.text = DBManager.partidasGanadas.ToString();
        niveles.text = DBManager.nivel.ToString();
        score.text = DBManager.puntuacionTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void volverMetodo()
    {
        SceneManager.LoadScene("PantallaInicio");
    }
}
