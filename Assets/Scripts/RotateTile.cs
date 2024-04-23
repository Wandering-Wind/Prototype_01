using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float rotZ;
    public float rotationSpeed;
    public bool ClockwiseRotation;

    // Start is called before the first frame update
    void Start()
    {
        //this code just constantly rotates tiles at the moment
        // we would have to change it so that when the gates line up
        // then only the rotation happen to align the gates
        //rotation should be worked on after we do the gates thing
    }

    // Update is called once per frame
    void Update()
    {
        //This is code for continuous rotation
        //if (ClockwiseRotation == false)
        //{
        //    rotZ = Time.deltaTime * rotationSpeed;
        //}
        //else
        //{
        //    rotZ += -Time.deltaTime * rotationSpeed;
        //}

        //transform.rotation = Quaternion.Euler(0,0,rotZ);
    }

    private void OnMouseDown()
    {
        Debug.Log("clicks");
        transform.Rotate(0, 0, -90);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform, true);
        }
    }
}
