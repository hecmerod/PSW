using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public string sceneName;
    private Scene mi_escena;
    
    public void Reiniciar()
    {
        mi_escena = SceneManager.GetActiveScene();
        sceneName = mi_escena.name;
        SceneManager.LoadScene(sceneName);
    }

    public void Salir()
    {
        GameProperties.getInstance().Reset();
        SceneManager.LoadScene("PantallaInicio");
    }

    public void Continuar()
    {

    }
}
