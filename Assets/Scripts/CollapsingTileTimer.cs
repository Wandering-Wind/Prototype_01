using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingTileTimer : MonoBehaviour
{
    public float timer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
