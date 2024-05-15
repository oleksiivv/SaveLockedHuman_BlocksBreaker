using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsController : MonoBehaviour
{
    public GameObject[] maps;

    void Start(){
        foreach(var map in maps)map.SetActive(false);

        maps[PlayerPrefs.GetInt("current",0)].SetActive(true);
    }
}
