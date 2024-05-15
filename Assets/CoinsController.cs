using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinsController : MonoBehaviour
{
    public Text coinsText;

    void Start(){
        showCoinsText();
    }

    public void showCoinsText(){
        coinsText.text=PlayerPrefs.GetInt("coins").ToString();
    }
}
