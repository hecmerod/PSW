using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public static bool Pausado = false;
    public static bool checkerSalir = false;
    public static bool checkerReiniciar = false;
    public static bool checkerAjustes = false;
    public GameObject menuPausaUI;
    public GameObject salirPreguntaUI;
    public GameObject ajustes;
    public string sceneName;
    public Scene mi_escena;
    public AudioMixer audioMixer;
    public Slider sli;
    public AudioMixer audioMixer2;
    public Slider sli2;


    void Awake()
    {
        resetStatic();
        float music = PlayerPrefs.GetFloat("Volumen", 0.236f);
        CambiarVolumen(music);
        sli.value = music;
        float sonidos = PlayerPrefs.GetFloat("sonido", 1f);
        CambiarSonido(sonidos);
        sli2.value = sonidos;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (checkerSalir == false & checkerReiniciar == false & checkerAjustes == false)
            {
                if (Pausado) {
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
    public void Pausar()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        Pausado = true;
    }
    public void cargarOpciones()
    {
        ajustes.SetActive(true);
        menuPausaUI.SetActive(false);
        checkerAjustes = true;
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
            GameProperties.Reset();
            Pausado = false;
            SceneManager.LoadScene("PantallaInicio"); 
        }
        else
        {
            mi_escena = SceneManager.GetActiveScene();
            sceneName = mi_escena.name;
            //Pausado = false;
            SceneManager.LoadScene(sceneName);
        }
    }
    public void vuelvoDeQuitar()
    {
        menuPausaUI.SetActive(true);
        salirPreguntaUI.SetActive(false);
        ajustes.SetActive(false);
        if (checkerSalir == true) { checkerSalir = false; }
        else { 
            checkerReiniciar = false;
            checkerAjustes = false;
        }
    }
    public void reiniciar() {
        GameProperties.PresetSettings("pequeño");
        menuPausaUI.SetActive(false); 
        salirPreguntaUI.SetActive(true);
        checkerReiniciar = true;
    }
    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
        PlayerPrefs.SetFloat("Volumen", volumen);
        PlayerPrefs.Save();
    }
    public void CambiarSonido(float volumen)
    {
        audioMixer2.SetFloat("sonido", volumen);
        PlayerPrefs.SetFloat("sonido", volumen);
        PlayerPrefs.Save();
    }

    //public void SetQuality(int qualityIndex)
    //{
    //    QualitySettings.SetQualityLevel(qualityIndex);
    //}
    public void vuelvoAjustes()
    {
        menuPausaUI.SetActive(true);
        ajustes.SetActive(false);
        checkerAjustes = false;
    }
    private void resetStatic()
    {
        Pausado = false;
        checkerSalir = false;
        checkerReiniciar = false;
        checkerAjustes = false;
    }



}
