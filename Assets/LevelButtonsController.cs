using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonsController : MonoBehaviour
{
    public Image[] levelItems;
    public Image[] levelClosed;

    public MenuController menu;

    void Start(){
        openAllLevels();
        for(int i=PlayerPrefs.GetInt("level",1); i<levelClosed.Length; i++){
            levelClosed[i].gameObject.SetActive(true);
        }
    }

    void openAllLevels(){
        for(int i=0; i<levelClosed.Length; i++){
            levelClosed[i].gameObject.SetActive(false);
        }
    }

    public void openLevel(int id){
        if(PlayerPrefs.GetInt("level",1)>=id){
            menu.openScene(id);
        }
    }
}
