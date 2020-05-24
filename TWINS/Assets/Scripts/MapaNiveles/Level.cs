using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int level;

    public Vector3[] cardsPosition;
    public Vector3 positionTablero;
    public Vector3 cronoPosition;
    public Vector3 puntuacionPosition;
    public IPuntuacion puntuacion;
    private bool locked = false;
    private Renderer renderer;
    public string baraja;

    public bool vNiño;

    private void Awake() {
        renderer = GetComponent<Renderer>();

        isUnlocked();
    }

    private void isUnlocked() {
        if (!vNiño)
        {
            if (DBManager.nivel < level)
            {
                renderer.material.color = Color.gray;
                locked = true;
            }
            else if (DBManager.nivel == level)
            {
                renderer.material.color = Color.blue;
            }
        }
        else {
            if (DBManager.nivelniños < level)
            {
                renderer.material.color = Color.gray;
                locked = true;
            }
            else if (DBManager.nivelniños == level)
            {
                renderer.material.color = Color.red;
            }
        }
    }


    private void OnMouseDown() {
        if (locked) return;

        GameProperties.SetProperties(level, cardsPosition, positionTablero, cronoPosition, puntuacionPosition, new PuntuacionFacil(), baraja, vNiño);
        Debug.Log(baraja);
        SceneManager.LoadScene("Partida");        
    }
    private void OnMouseEnter()
    {
        if (locked) return;
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnMouseExit() {
        if (locked) return;
        transform.localScale = Vector3.one;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
