using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Yodo1.MAS;

public class MenuController : ScenesManager
{
    public GameObject levelsPanel, ballsPanel;

    //private AdmobController admob;

    void Start()
    {

    }

    public void setLevelsPanelVisible(bool visible){
        levelsPanel.SetActive(visible);
    }

    public void setBallsPanelVisible(bool visible){
        ballsPanel.SetActive(visible);
    }

    public void startGame(){
        openScene(PlayerPrefs.GetInt("level",1));
    }
}
