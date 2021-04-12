using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCamBehavior : MonoBehaviour
{
    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, 30, target.position.z);
        this.transform.eulerAngles = new Vector3(90, target.transform.eulerAngles.y, 0);
    }
}
