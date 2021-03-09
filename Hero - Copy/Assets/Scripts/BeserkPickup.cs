using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeserkPickup : MonoBehaviour
{
    public bool isBeserk = false;
    /*private float targetTime = 15.0f;*/
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (isBeserk == false)
            {
                isBeserk = true;
                Destroy(this.transform.parent.gameObject);
                Debug.Log("Beserk Mode Activated!");
            }
            
        }

    }
    /*void Update()
    {
        if (isBeserk)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }           
    }
    void OnGUI()
    {
        if (isBeserk)
        {
            GUI.Box(new Rect(Screen.width / 2 - 125, Screen.height / 2, 225, 25), "BESERK MODE ACTIVATED!!");
        }
    }
    void timerEnded()
    {
        targetTime = 15.0f;
        isBeserk = false;
    }*/
}
