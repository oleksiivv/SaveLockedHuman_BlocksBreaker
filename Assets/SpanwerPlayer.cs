using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwerPlayer : MonoBehaviour
{
    
    public GameObject player;
    public Vector3 spawnPos;
    public LevelController level;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player" && level.alive){
        Debug.Log("Spanwer");

            spawn();
        }
    }

    public void spawn(){
        if(level.spheresNumber<=0 && !level.win){
            level.panels.setDeathPanelVisibility(true);
            level.alive=false;
        }
        else if(!level.win){
            var newPlayer = Instantiate(player, spawnPos, Quaternion.Euler(0,0,0)) as GameObject;

            Destroy(player);
            
            player=newPlayer;
        }
    }

    public void LoseBehavior(){
        level.panels.setDeathPanelVisibility(true);
        level.alive=false;

        Destroy(player);
    }
}
