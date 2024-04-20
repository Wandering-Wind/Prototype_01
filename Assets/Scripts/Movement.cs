using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moovement : MonoBehaviour
{
    //basic movement script without the block to block ting
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector3(speedX, speedY);
    }
}
