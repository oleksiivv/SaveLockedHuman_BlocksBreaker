using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLevelController : MonoBehaviour
{
    public WaterLevelController waterLevelController;

    public GameObject startButton;

    public void StartLevel(){
        startButton.SetActive(false);

        waterLevelController.StartWater();
    }
}
