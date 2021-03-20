using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    public AudioSource music;
    public AudioSource room_drone;
    // Start is called before the first frame update
    void Start()
    {
        music.Play();
        room_drone.Play();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
