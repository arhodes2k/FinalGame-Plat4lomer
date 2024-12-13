using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class zomLerpTest : MonoBehaviour
{
    Animator anim;
    bool attackZoneHit;
    //can also do [SerializeField] Transform player, and just have the transform attached.
    [SerializeField] GameObject player;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim.SetBool("idle", true);
        //might not matter if you're moving with a lerp, but if it makes you feel better :p
       // float speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       float distance = UnityEngine.Vector3.Distance(transform.position, player.transform.position);
       if (anim.GetBool("run")){
        // your trans.pos = Vector2.Lerp(the position of your object, the position of the object you want to go towards, the increment);
        // transform.position = Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime);
        // the increment here is Time.deltaTime but it can be any value * t.dT as well to make it faster or slower. I think?? was buggy. 
        
        
        // was getting an error with just Vector2, so I made them all UnityEngine.Vector2 but it shouldnt matter tbh. 
      

      UnityEngine.Vector2 playerVector = player.transform.position; 
      UnityEngine.Vector2 leftBoundary = playerVector - new UnityEngine.Vector2(2f, 0f);
      UnityEngine.Vector2 rightBoundary = playerVector + new UnityEngine.Vector2(2f, 0f);

    
        if(transform.position.x > player.transform.position.x){

            spriteRenderer.flipX = true; 
            transform.position = UnityEngine.Vector2.Lerp(transform.position, rightBoundary, Time.deltaTime);

        }

        if(transform.position.x < player.transform.position.x){
            transform.position = UnityEngine.Vector2.Lerp(transform.position, leftBoundary, Time.deltaTime);
        }

       }
       if (distance < 3f){
        //make sure your animations' loop time is toggled so it doesn't start then stop. 
        //you can do so in the project, just select the specific animation in the project window and toggle Loop Time in inspector
        anim.SetBool("run", false);
        anim.SetBool("attack", true);
       } else {

        anim.SetBool("run", true);
        anim.SetBool("attack", false);
       }
        
       


    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Player"){
            anim.SetBool("run", true); 
            anim.SetBool("idle", false);

            
        }
    }

    void OnTriggerExit2D (Collider2D col){
        anim.SetBool("idle", true);
       // speed = 0f;
    }
}
