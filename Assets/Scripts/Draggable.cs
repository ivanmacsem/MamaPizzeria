using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //If image doesn't move in proportion to the canvas, add canvas to this slot and divide eventdata.delta by canvas on line 27
   //[SerializeField] Canvas canvas;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)

    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)

    {
        //Debug.Log("OnDrag");
        //rectTransform.anchoredPosition += eventData.delta;  
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)

    {
        Debug.Log("OnEndDrag");
    }
 public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}