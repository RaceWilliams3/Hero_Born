using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Ammo Gained!");
            PlayerBehaviour _PB = collision.gameObject.GetComponent<PlayerBehaviour>();
            _PB.ammo += 10;
        }

    }
}
