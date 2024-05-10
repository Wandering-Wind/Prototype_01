using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickMovement : MonoBehaviour
{
    public static List<MouseClickMovement> movableObjects = new List<MouseClickMovement>();
    private bool selected;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        movableObjects.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        selected = true;
        gameObject.GetComponent<SpriteRenderer>().color = UnityEngine.Color.blue;

        foreach (MouseClickMovement obj in movableObjects)
        {
            if (obj != this)
            {
                obj.selected = false;
                obj.gameObject.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;

            }
        }

    }
}