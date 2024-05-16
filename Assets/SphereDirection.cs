using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SphereDirection : MonoBehaviour
{
    public Slider directionSlider;
    public Rigidbody rb;

    private bool canLaunch=true;
    public GameObject directionArrow;
    public LevelController level;
    public SpanwerPlayer spawner;

    private bool landed=false;
    public ParticleSystem destroyEffect;

    private int collisionCnt=0;


    private int maxCollisionsCnt=300;

    void Start(){
        directionSlider.minValue=-90;
        directionSlider.maxValue=90;

        directionSlider.value=0;

        canLaunch=true;
        landed=false;
        collisionCnt=0;
        directionArrow.SetActive(landed);
    }


    void Update(){
        if(canLaunch && level.alive && !level.win && landed ){
            transform.eulerAngles=new Vector3(transform.eulerAngles.x, -directionSlider.value, transform.eulerAngles.z);

            if(Input.GetMouseButtonUp(0) && !PanelsController.panelsOn){
                rb.AddRelativeForce(Vector3.forward*-600, ForceMode.Force);
                canLaunch=false;
                directionArrow.SetActive(false);
                //level.setSpheresDelta(1);
            }

        }
        else if((!canLaunch && rb.velocity.magnitude<=0.2f) || collisionCnt>=maxCollisionsCnt){
            Debug.Log(rb.velocity.magnitude);
            rb.velocity*=0.95f;
            Invoke(nameof(createNew),1.5f);
        }

        //Debug.Log("Velocity magnitude: "+rb.velocity.magnitude);
    }


    void createNew(){
        destroyEffect.gameObject.transform.parent=null;
        destroyEffect.Play();
        spawner.spawn();
    }

    void OnCollisionEnter(Collision collision){
        //rb.AddForce(Vector3.forward*-300, ForceMode.Force);
        if(collision.gameObject.tag!="Ground"){
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.normal.y < 0.1f)
                {
                    Debug.DrawRay(contact.point, contact.normal, Color.yellow, 5f);
                    
                    rb.AddForce(contact.normal * 1.34f, ForceMode.Impulse);
                    //rb.AddForce(Vector3.up * 3f, ForceMode.Impulse);
                
                }
            }
            collisionCnt++;
        }
        if(landed==false){
            landed=true;
            directionArrow.SetActive(true);
        }
    }
}
