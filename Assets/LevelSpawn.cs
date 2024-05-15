using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    [System.Serializable]
    public struct Map{
        public int[] row;
    }

    public Map[] map = new Map[5]; 

    public GameObject[] cubes;
    public Vector3 topLeft;
    public LevelController level;

    public List<GameObject> createdCubes = new List<GameObject>();

    public float diffCoef=1.25f;

    void Start(){

        StartCoroutine(spawnMap());

    }

    IEnumerator spawnMap(){
        PanelsController.panelsOn=true;
        for(int i=0;i<map.Length;i++){
            for(int j=0;j<map[0].row.Length;j++){
                if(map[i].row[j]!=0){
                    var obj = Instantiate(cubes[map[i].row[j]-1], 
                                new Vector3(topLeft.x-(j*cubes[map[i].row[j]-1].transform.localScale.x*diffCoef), topLeft.y,topLeft.z+(i*cubes[map[i].row[j]-1].transform.localScale.z*diffCoef)),
                                Quaternion.identity) as GameObject;

                    obj.GetComponent<GameCube>().levelSpawner=this;
                    createdCubes.Add(obj);
                    yield return new WaitForSeconds(0.05f);
                }

            }
        }
        PanelsController.panelsOn=false;
    }
}
