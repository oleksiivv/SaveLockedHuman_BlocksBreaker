using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterial : MonoBehaviour
{
    public Material[] skins;
    public MeshRenderer mesh;


    void Start(){
        mesh.material = skins[PlayerPrefs.GetInt("CurrentPlayerMaterial",0)];
    }
}
