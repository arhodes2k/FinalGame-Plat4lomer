using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
    
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float speed = 2f;
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
