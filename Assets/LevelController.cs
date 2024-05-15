using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public int spheresNumber;
    public Text spheresLabel;

    public PanelsController panels;

    [HideInInspector()]
    public bool alive=true;

    [HideInInspector()]
    public bool win=false;

    public WaterLevelController waterLevelController;

    void Start(){
        //setLabelValue();

        if(waterLevelController){
            waterLevelController.StartWater();
        }
    }

    public void setSpheresDelta(int delta){
        //spheresNumber-=delta;
        //setLabelValue();
    }

    public void setLabelValue(){
        //spheresLabel.text=spheresNumber.ToString();
    }
}
