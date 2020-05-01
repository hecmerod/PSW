using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideCamera : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Camera camera;

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("OnMouseEnter");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        print("OnMouseExit");
    }
}
