using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasCrearBaraja : MonoBehaviour
{
    private Elegidas elegidas;
    public GameObject elegirTamaño;

    private void Start() {
        elegidas = FindObjectOfType<Elegidas>();
    }

    public void volver()
    {        
        SceneManager.LoadScene("PantallaInicio");
    }

    public void EmpezarPartida() {
        for (int i = 0; i < 16; i++)
        {
            if (elegidas.posiciones[i].transform.childCount == 0)
            {
                Debug.Log("La baraja no está completa");
                return;
            }
            else
            {
                Personalizada.sprites[i] = elegidas.posiciones[i].transform.GetChild(0).name;
            }
        }

        GameProperties.baraja = "personalizada";

        elegirTamaño.SetActive(true);
    }
    public void Pequeño()
    {
        GameProperties.PresetSettings("pequeño");
        SceneManager.LoadScene("Partida");
    }
    public void Mediano()
    {
        GameProperties.PresetSettings("mediano");
        SceneManager.LoadScene("Partida");
    }
    public void Garnde()
    {
        GameProperties.PresetSettings("grande");
        SceneManager.LoadScene("Partida");
    }
}
