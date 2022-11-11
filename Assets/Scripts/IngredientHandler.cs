using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IngredientHandler : MonoBehaviour
 {   
    private Vector2 origPos;
    public bool returnToOrigin = false;

    void Start(){
        origPos = transform.position;
    }

    void OnMouseUp(){
        if(returnToOrigin){
            transform.position = origPos;
            //Destroy(ingredientSprite??.GameObject)
        }
    }

 }