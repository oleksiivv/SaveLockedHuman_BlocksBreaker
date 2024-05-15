using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameCube : MonoBehaviour
{
    public int level;

    public TextMeshPro[] values;

    public ParticleSystem destroyEffect, collisionEffect;

    public LevelSpawn levelSpawner;

    public GameObject coin;

    void Start(){
        updateCubeValues();
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Player"){
            level--;
            updateCubeValues();

            if(level<=0){
                destroyEffect.gameObject.transform.parent=null;
                destroyEffect.Play();

                levelSpawner.createdCubes.Remove(gameObject);

                if(levelSpawner.createdCubes.Count==0){
                    levelSpawner.level.panels.setWinPanelVisibility(true);
                    levelSpawner.level.win=true;
                }

                if(UnityEngine.Random.Range(0,4)==1){
                    Instantiate(coin, new Vector3(gameObject.transform.position.x, coin.transform.position.y, gameObject.transform.position.z), coin.transform.rotation);
                }
                Destroy(gameObject);
            }
            else{
                collisionEffect.Play();
            }
        }
    }

    void updateCubeValues(){
        foreach (var item in values)
        {
            item.text=level.ToString();
        }
    }
    
}
