
using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    public PizzaSlot currentSlot;
    public GameObject myPrefab;
    private GameObject instance;
    private RectTransform instRect;
    private bool dragging;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!dragging){
	        instance = Instantiate(myPrefab, eventData.position, Quaternion.identity, rectTransform);
	        instRect = instance.GetComponent<RectTransform>();
            dragging = true;
        }
        instRect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
        if(instRect.parent == rectTransform){
            Destroy(instance);
        }
    }

    public GameObject getInstance(){
        return instance;
    }
}