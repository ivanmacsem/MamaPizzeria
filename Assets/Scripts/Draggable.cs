
using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    public PizzaSlot currentSlot;
     public GameObject myPrefab;


    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)

    {
       // Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)

    {
        //rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)

    {
        //Debug.Log("OnEndDrag");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
         Instantiate(myPrefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), Quaternion.identity);
    }
}