using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PizzaSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<Draggable>().getInstance().GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
            eventData.pointerDrag.GetComponent<Draggable>().getInstance().GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        }
    }
}
