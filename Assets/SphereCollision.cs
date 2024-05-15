using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
     //public ParticleSystem coinCollisionEffect;

     public CoinsController coins;

     void Start(){
         coins.showCoinsText();
     }


     void OnTriggerEnter(Collider other){
         if(other.gameObject.tag=="Coin"){
             ParticleSystem coinGetEffect = other.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<ParticleSystem>();
             coinGetEffect.gameObject.transform.parent=null;
             coinGetEffect.Play();
             PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")+1);
             coins.showCoinsText();
             Destroy(other.gameObject);
         }
     }
}
