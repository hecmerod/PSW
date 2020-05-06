using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int level;

    public Vector3[] cardsPosition;
    private LevelProperties levelProperties;    
    public IPuntuacion puntuacion;
    private bool blocked;
    private void Awake() {
        levelProperties = GameObject.FindObjectOfType<LevelProperties>();

        if (DBManager.nivel < level) blocked = true;
    }

    private void OnMouseDown() {
        if (blocked) return;
        levelProperties.SetProperties(level, cardsPosition, new PuntuacionFacil());

        SceneManager.LoadScene("PartidaEstandar");        
    }

    private void OnMouseEnter()
    {
        if (blocked) return;
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    void OnMouseExit() {
        if (blocked) return;
        transform.localScale = Vector3.one; 
    }
}
