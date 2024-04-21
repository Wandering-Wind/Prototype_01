using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour

{
    //basic movement script without the block to block ting
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

       rb = GetComponent<Rigidbody2D>(); 

       //rb = GetComponent<Rigidbody2D>(); 

    }

    // Update is called once per frame
    void Update()
    {

        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector3(speedX, speedY);

        //speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        //speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        //rb.velocity = new Vector3(speedX, speedY);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.Translate(0, 1.25f, 0);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            transform.Translate(0, -1, 25f, 0);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Translate(-1.25f, 0, 0);
        else if (Input.GetKeyDown(KeyCode.RightArrow))

            transform.Translate(1.25f, 0, 0);
       


    }
}
