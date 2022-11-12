using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PizzaSlot : MonoBehaviour, IDropHandler
{
    
    [SerializeField] Pizza curPiz = null;
    [SerializeField] GameController controller = null;

    private bool topR = false;
    private bool topL = false;
    private bool bot = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<Draggable>().getInstance().GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
            tryAdding(eventData.pointerDrag.GetComponent<Draggable>().gameObject.GetComponent<Ingredient>());
            eventData.pointerDrag.GetComponent<Draggable>().getInstance().GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        }
    }
    void Update()
    {
        //if(curPiz.IsPizzaFull()){
            //controller.Finished();
        //}
    }
    public void tryAdding(Ingredient i){
        Debug.Log("Tried to add" + i.ingCode);
    }
    //{check position, then using that check the bool corresponding to that section, if empty -> curPiz.AddIngredient(i, 1 if topR or topL or 2 if bot)}
}
