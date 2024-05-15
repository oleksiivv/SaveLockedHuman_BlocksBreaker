using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInWaterController : MonoBehaviour
{
    private Animator animator;

    private bool alive=true;
    private bool won=false;

    void Start(){
        alive=true;
        won=false;

        animator = GetComponent<Animator>();
        animator.enabled = false;
        Invoke(nameof(StartAnimation), Random.Range(0.2f, 1f));

        Invoke(nameof(RandomMovement), Random.Range(1f, 5f));
    }

    void RandomMovement(){
        if(alive && !won && IsNotMenu()){
            animator.SetBool("attack", true);
            Invoke(nameof(RandomMovement), Random.Range(5f, 14f));
        }
    }

    void StartAnimation(){
        animator.enabled = true;
    }

    public void Death(){
        alive=false;
        animator.SetBool("die", true);
    }

    public void Win(){
        won=true;
        animator.SetBool("damage", true);
    }

    private bool IsNotMenu(){
        return Application.loadedLevel>0;
    }
}
