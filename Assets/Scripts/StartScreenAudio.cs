using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenAudio : MonoBehaviour
{
    [Header("----Audio Source----")]
    [SerializeField] AudioSource startsceneSource;

    [Header("----Audio Clip----")]
    public AudioClip startScreenMusic;
    // Start is called before the first frame update
    void Start()
    {
        startsceneSource.clip = startScreenMusic;
        startsceneSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
