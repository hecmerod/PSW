﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool Pausado = false;
    public static bool checkerSalir = false;
    public static bool checkerReiniciar = false;
    public GameObject menuPausaUI;
    public GameObject salirPreguntaUI;
    public string sceneName;
    public Scene mi_escena;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (checkerSalir == false && checkerReiniciar == false)
            {
                if (Pausado)
                {
                    Reanudar();
                }
                else
                {
                    Pausar();
                }
            }
            else
            {
                vuelvoDeQuitar();
            }
        }
    }
    public void Reanudar()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        Pausado = false;
    }
    void Pausar()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        Pausado = true;
    }
    public void cargarOpciones()
    {
        //Sprint 3
    }
    public void quitarPartida()
    {
        menuPausaUI.SetActive(false);
        salirPreguntaUI.SetActive(true);
        checkerSalir = true;
    }
    public void quitarDefinitivo()
    {
        Time.timeScale = 1f;
        if(checkerSalir == true) {
            //METER AQUI DELETE LEVELPROPERTIES SI HAY
            SceneManager.LoadScene("PantallaInicio"); 
        }
        else
        {
            mi_escena = SceneManager.GetActiveScene();
            sceneName = mi_escena.name;
            SceneManager.LoadScene(sceneName);
        }
    }
    public void vuelvoDeQuitar()
    {
        menuPausaUI.SetActive(true);
        salirPreguntaUI.SetActive(false);
        if(checkerSalir == true) { checkerSalir = false; }
        else { checkerReiniciar = false; }
    }
    public void reiniciar()
    {
        menuPausaUI.SetActive(false); 
        salirPreguntaUI.SetActive(true);
        checkerReiniciar = true;
    }


    
}
