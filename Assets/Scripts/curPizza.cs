using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curPizza : MonoBehaviour
{
    [SerializeField] Pizza curPiz = null;
    [SerializeField] GameController controller = null;
    void Update()
    {
        if(curPiz.IsPizzaFull()){
            //controller.Finished();
        }
    }
}
