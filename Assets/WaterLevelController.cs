using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelController : MonoBehaviour
{
    public GameObject water;

    public CharacterInWaterController character;

    public List<CharacterInWaterController> extraCharacters;

    public float delay;

    public Vector3 targetWaterPosition;

    public Vector3 startWaterPosition;

    public ParticleSystem waterFX;

    private bool isMoveWater = false;

    public SpanwerPlayer player;

    public float speed = 1;
    public float speedCoef = 1;

    public List<Rigidbody> frontWallBricks;

    public ParticleSystem breakWallEffect;

    public void StartWater(){
        speed=1;
        waterFX.Play();

        isMoveWater = true;
        StartCoroutine(MoveWater());
    }

    void Update(){
        //Debug.Log("Dif: "+water.transform.position.y.ToString()+"   "+targetWaterPosition.y.ToString());
        if(water.transform.position.y >= targetWaterPosition.y && isMoveWater){
            //StopWater();
            GameOver();
        }

        if(water.transform.position.y > targetWaterPosition.y + 2) {
            speed = 0;
        }
    }

    public void StopWater(){
        isMoveWater = false;
    }

    public void OnPlayerWinHandle(){
        waterFX.Stop();
        speed=-3;
        speedCoef=1;

        foreach(var brick in frontWallBricks){
            brick.AddForce(Vector3.forward*Random.Range(50, 80));
            brick.AddForce(Vector3.up*Random.Range(50, 80));
        }

        breakWallEffect.Play();

        AnimateCharacterWin();
        Invoke(nameof(AnimateCharacterWin), 1f);
        Invoke(nameof(AnimateCharacterWin), 2f);
    }

    void AnimateCharacterWin(){
        character.Win();

        foreach(var extraCharacter in extraCharacters){
            extraCharacter.Win();
        }
    }

    IEnumerator MoveWater(){
        while(isMoveWater){
            water.transform.Translate(Vector3.up/50 * speed * speedCoef);

            yield return new WaitForSeconds(delay);
        }
    }

    public void GameOver(){
        character.Death();
        player.LoseBehavior();

        foreach(var extraCharacter in extraCharacters){
            extraCharacter.Death();
        }
    }
}
