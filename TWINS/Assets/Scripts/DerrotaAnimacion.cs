using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DerrotaAnimacion : MonoBehaviour
{
    public GameObject animacionAActivar;
    public Text miTiempo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animacionAActivar.SetActive(true);
    }

    public void setTime(float time)
    {
        miTiempo.text = time.ToString();
    }
}
