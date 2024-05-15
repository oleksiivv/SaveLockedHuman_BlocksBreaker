using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingSlider;
    IEnumerator loadAsync(int id)
    {
        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            yield return null;

        }
    }

    //private static AdmobController admob;


    //public static int addCnt=1;

    //private string appId="4234609";

    protected void Start(){
        /*Advertisement.Initialize(appId,false);

        if(admob==null)admob=new AdmobController();

        admob.init();

        if(addCnt%3==0){
            if(Advertisement.IsReady()){
                Advertisement.Show("Interstitial_Android");
            }
            else{
                admob.showIntersitionalAd();
            }
            
        }*/
    }
    public void openScene(int id){
        
        //addCnt++;
        Time.timeScale=1;
        StartCoroutine(loadAsync(id));
    }






    
}
