using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PizzaSlot : MonoBehaviour, IDropHandler
{
    
    public Pizza pizza = null;
    [SerializeField] GameController controller = null;
    [SerializeField] GameObject[] topRVisuals = new GameObject[7];
    [SerializeField] GameObject[] topLVisuals = new GameObject[7];
    [SerializeField] GameObject[] botVisuals = new GameObject[7];

    private bool topR = false;
    private bool topL = false;
    private bool bot = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject dragged = eventData.pointerDrag.GetComponent<Draggable>().getInstance();
            dragged.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
            tryAdding(dragged.GetComponent<RectTransform>().anchoredPosition, dragged.GetComponent<Ingredient>());
        }
    }
    public void tryAdding(Vector2 pos, Ingredient i){
        if(pos.y <= 0){
            if(!bot){
                pizza.AddIngredient(i, 2);
                bot = true;
                botVisuals[i.ingCode].SetActive(true);
            }
        }
        else if(pos.x >= 0){
            if(!topR){
                pizza.AddIngredient(i, 1);
                topR = true;
                topRVisuals[i.ingCode].SetActive(true);
            }
        }
        else if(pos.x < 0){
            if(!topL){
                pizza.AddIngredient(i, 1);
                topL = true;
                topLVisuals[i.ingCode].SetActive(true);
            }
        }
        if(topL && topR && bot){
            controller.Finished();
            StartCoroutine(WaitToShow(1f));
        }
    }
    public void reset(){
        foreach(GameObject g in botVisuals){
            g.SetActive(false);
        }
        bot = false;
        foreach(GameObject g in topLVisuals){
            g.SetActive(false);
        }
        topL = false;
        foreach(GameObject g in topRVisuals){
            g.SetActive(false);
        }
        topR = false;
    }
    IEnumerator WaitToShow(float pauseDuration){
        yield return new WaitForSeconds(pauseDuration);
        pizza.resetPizza();
        reset();
    }
}
