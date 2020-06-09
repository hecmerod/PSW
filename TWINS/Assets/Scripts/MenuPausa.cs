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
    public AudioMixer audioMixerMusica;
    public Slider sliderMusica;
    public AudioMixer audioMixerSonidos;
    public Slider sliderSonido;
    public Slider sliderBrillo;
    public float rbgValue = 0.1f;

    public GameObject bloqueo;
    void Awake()
    {
        LoadSettings();
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
    void LoadSettings()
    {
        resetStatic();
        float music = PlayerPrefs.GetFloat("Volumen", 0.236f);
        CambiarVolumen(music);
        sliderMusica.value = music;
        float sonidos = PlayerPrefs.GetFloat("sonido", 1f);
        CambiarSonido(sonidos);
        sliderSonido.value = sonidos;
        float cbrillo = PlayerPrefs.GetFloat("Brillo", 0.1f);
        cambiarBrillo(cbrillo);
        sliderBrillo.value = cbrillo;
    }
    public void Reanudar()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        Pausado = false;
        bloqueo.SetActive(false);
    }
    public void Pausar()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        Pausado = true;
        bloqueo.SetActive(true);
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
        audioMixerMusica.SetFloat("Volumen", volumen);
        PlayerPrefs.SetFloat("Volumen", volumen);
        PlayerPrefs.Save();
    }
    public void CambiarSonido(float volumen)
    {
        audioMixerSonidos.SetFloat("sonido", volumen);
        PlayerPrefs.SetFloat("sonido", volumen);
        PlayerPrefs.Save();
    }
    public void cambiarBrillo(float brillo)
    {
        RenderSettings.ambientLight = new Color(brillo, brillo, brillo, 1);
        PlayerPrefs.SetFloat("Brillo", brillo);
        PlayerPrefs.Save();
    }
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
