using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasCrearBaraja : MonoBehaviour
{
    private Elegidas elegidas;

    private void Start() {
        elegidas = FindObjectOfType<Elegidas>();
    }

    public void volver()
    {
        for(int i = 0; i < 15; i++){
            if (elegidas.posiciones[i].transform.childCount == 0)
            {
                Debug.Log("La baraja no está completa");
                return;
            }
            else {
                Personalizada.sprites[i] = elegidas.posiciones[i].transform.GetChild(0).name;
            }
        }
        SceneManager.LoadScene("PantallaInicio");
    }
}
