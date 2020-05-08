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
    public IPuntuacion puntuacion;
    private bool locked = false;
    private Renderer renderer;

    private void Awake() {
        renderer = GetComponent<Renderer>();

        isUnlocked();
    }

    private void isUnlocked() {
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


    private void OnMouseDown() {
        if (locked) return;
        GameProperties.SetProperties(level, cardsPosition, positionTablero, cronoPosition, new PuntuacionFacil());

        SceneManager.LoadScene("PartidaEstandar");        
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
