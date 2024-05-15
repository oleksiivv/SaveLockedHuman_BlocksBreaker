using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    public GameObject[] elements;


    protected void Start(){
        setElementsVisibility(false);
        Invoke(nameof(showAll),1.1f);
    }

    protected void showAll(){
        setElementsVisibility(true);
    }

    protected void setElementsVisibility(bool visibility){
        foreach(var el in elements){
            el.SetActive(visibility);
        }
    }
}
